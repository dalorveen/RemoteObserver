// WinsockServer.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"

#define DEFAULT_BUFLEN 512
#define DEFAULT_PORT "49073"

typedef std::vector<BYTE> vecByte;

std::vector<std::wstring> _titles;

BOOL CALLBACK enumWindowsProc(__in HWND hWnd, __in LPARAM lParam)
{
	int length = ::GetWindowTextLength(hWnd);
	if (0 == length) return TRUE;

	TCHAR* buffer;
	buffer = new TCHAR[length + 1];
	memset(buffer, 0, (length + 1) * sizeof(TCHAR));

	GetWindowText(hWnd, buffer, length + 1);

	if (IsWindowVisible(hWnd))
	{
		std::wstring t(buffer, length + 1);
		_titles.push_back(t);
	}
	
	delete[] buffer;
	return TRUE;
}

bool save_img(const CImage &image, vecByte &buf)
{
	IStream *stream = NULL;
	HRESULT hr = CreateStreamOnHGlobal(0, TRUE, &stream);
	if (!SUCCEEDED(hr))
		return false;
	image.Save(stream, Gdiplus::ImageFormatPNG);
	ULARGE_INTEGER liSize;
	IStream_Size(stream, &liSize);
	DWORD len = liSize.LowPart;
	IStream_Reset(stream);
	buf.resize(len);
	IStream_Read(stream, &buf[0], len);
	stream->Release();
	return true;
}

std::vector<unsigned char> intToBytes(int paramInt)
{
	std::vector<unsigned char> arrayOfByte(4);
	for (int i = 0; i < 4; i++)
		arrayOfByte[i] = (paramInt >> (i * 8));
	return arrayOfByte;
}

vecByte package(char object_id, size_t size_of_object_data, vecByte data)
{
	vecByte package;

	// HEADER
	package.push_back('H');
	package.push_back('E');
	package.push_back('A');
	package.push_back('D');
	package.push_back('E');
	package.push_back('R');

	// OBJECT_ID
	package.push_back(object_id);

	//SIZE_OF_OBJECT_DATA
	vecByte encoded_size = intToBytes(size_of_object_data);
	package.insert(package.end(), encoded_size.begin(), encoded_size.end());

	// OBJECT_DATA
	std::copy(data.begin(), data.end(), std::back_inserter(package));
	return package;
}

vecByte package(std::string message)
{
	size_t size_of_object_data = message.size();
	vecByte data;
	data.insert(data.end(), message.begin(), message.end());
	return package('0', size_of_object_data, data);
}

std::vector<std::wstring> parse(std::wstring keyCodes)
{
	std::vector<std::wstring> result;
	bool carry = false;
	for (size_t i = 0; i < keyCodes.size(); i++)
	{
		if (keyCodes[i] == '<')
		{
			carry = true;
			result.push_back(std::wstring());
			continue;
		}
		else if (keyCodes[i] == '>')
		{
			carry = false;
			continue;
		}
		else if (carry)
		{
			result.back() += keyCodes[i];
		}
	}
	return result;
}

void press_multikey(std::vector<std::wstring> kit, bool keyUp)
{
	for (std::vector<std::wstring>::iterator it = kit.begin(); it != kit.end(); ++it)
	{
		if (it->size() == 1)
		{
			if (!keyUp)
			{
				keybd_event((*it)[0], 0, 0, 0);
			}
			else
			{
				keybd_event((*it)[0], 0, KEYEVENTF_KEYUP, 0);
			}
		}
		else
		{
			char c = std::stoi(*it, 0, 16);
			if (!keyUp)
			{
				keybd_event(c, 0, 0, 0);
			}
			else
			{
				keybd_event(c, 0, KEYEVENTF_KEYUP, 0);
			}
		}
	}
}

void press_key(std::vector<std::wstring> keys)
{
	for (std::vector<std::wstring>::iterator it = keys.begin(); it != keys.end(); ++it)
	{
		if (it->size() == 1)
		{
			keybd_event((*it)[0], 0, 0, 0);
			Sleep(rand() % 50 + 125);
			keybd_event((*it)[0], 0, KEYEVENTF_KEYUP, 0);
		}
		else
		{
			std::wstringstream wss;
			wss << *it;
			std::wstring segment;
			std::vector<std::wstring> kit;

			while (std::getline(wss, segment, L'+'))
			{
				kit.push_back(segment);
			}

			press_multikey(kit, false);
			Sleep(rand() % 50 + 125);
			press_multikey(kit, true);
		}
	}
}

vecByte response(char* input, int size)
{
	std::string str(input, size);
	
	std::wstring_convert<std::codecvt_utf16<wchar_t>> converter;
	std::wstring wstr = converter.from_bytes(str);

	if(wstr.compare(L"<titles>") == 0)
	{
		EnumDesktopWindows(NULL, enumWindowsProc, NULL);

		//SIZE_OF_OBJECT_DATA
		std::wstring w_titles;
		for (std::vector<std::wstring>::iterator it = _titles.begin(); it != _titles.end(); ++it)
		{
			w_titles.append(*it);
			w_titles.append(L"<gap>");
		}
		std::string titles = converter.to_bytes(w_titles);
		_titles.clear();
		size_t size_of_object_data = titles.size();

		// OBJECT_DATA
		vecByte data;
		data.insert(data.end(), titles.begin(), titles.end());

		return package('1', size_of_object_data, data);
	}
	else if (wstr.find(L"<image>") != std::string::npos)
	{
		std::wstring title = wstr.substr(7);

		HWND hWnd;
		hWnd = FindWindow(NULL, title.c_str());
		
		if (hWnd != NULL)
		{
			RECT rect;
			GetWindowRect(hWnd, &rect);
			
			ATL::CImage* image_ = new CImage();
			image_->Create(rect.right - rect.left, rect.bottom - rect.top, 32);;
			
			HDC device_context_handle = image_->GetDC();
			PrintWindow(hWnd, device_context_handle, PW_CLIENTONLY);

			//SIZE_OF_OBJECT_DATA
			vecByte buf;
			bool b = save_img(*image_, buf);
			image_->ReleaseDC();
			delete image_;
			size_t size_of_object_data = buf.size();
			printf("Size of image: %d\n", size_of_object_data);

			// OBJECT_DATA
			vecByte data;
			data.insert(data.end(), buf.begin(), buf.end());

			return package('2', size_of_object_data, data);
		}
		else
		{
			std::wstring w_err = L"The window is not found.";
			std::string err = converter.to_bytes(w_err);
			return package(err);
		}
	}
	else if (wstr.find(L"<press>") != std::string::npos)
	{
		std::wstring key_code = wstr.substr(7);

		std::vector<std::wstring> keys = parse(key_code);
		press_key(keys);
		
		return package("OK");
	}
	else
	{
		std::wstring w_err = L"Invalid request.";
		std::string err = converter.to_bytes(w_err);
		return package(err);
	}
}

int __cdecl main(int argc, char* argv[])
{
	//_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);

	if (argc == 2)
	{
		if (std::string(argv[1]) == "--hide")
		{
			HWND hwnd = GetConsoleWindow();
			ShowWindow(hwnd, SW_HIDE);
		}
	}

	WSADATA wsaData;
	int iResult;

	SOCKET ListenSocket = INVALID_SOCKET;
	SOCKET ClientSocket = INVALID_SOCKET;

	struct addrinfo *result = NULL;
	struct addrinfo hints;

	int iSendResult;
	char recvbuf[DEFAULT_BUFLEN];
	int recvbuflen = DEFAULT_BUFLEN;

	// Initialize Winsock
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != 0) {
		printf("WSAStartup failed with error: %d\n", iResult);
		return 1;
	}

	ZeroMemory(&hints, sizeof(hints));
	hints.ai_family = AF_INET;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;
	hints.ai_flags = AI_PASSIVE;

	// Resolve the server address and port
	iResult = getaddrinfo(NULL, DEFAULT_PORT, &hints, &result);
	if (iResult != 0) {
		printf("getaddrinfo failed with error: %d\n", iResult);
		WSACleanup();
		return 1;
	}

	// Create a SOCKET for connecting to server
	ListenSocket = socket(result->ai_family, result->ai_socktype, result->ai_protocol);
	if (ListenSocket == INVALID_SOCKET) {
		printf("socket failed with error: %ld\n", WSAGetLastError());
		freeaddrinfo(result);
		WSACleanup();
		return 1;
	}

	// Setup the TCP listening socket
	iResult = bind(ListenSocket, result->ai_addr, (int)result->ai_addrlen);
	if (iResult == SOCKET_ERROR) {
		printf("bind failed with error: %d\n", WSAGetLastError());
		freeaddrinfo(result);
		closesocket(ListenSocket);
		WSACleanup();
		return 1;
	}

	freeaddrinfo(result);

	iResult = listen(ListenSocket, SOMAXCONN);
	if (iResult == SOCKET_ERROR) {
		printf("listen failed with error: %d\n", WSAGetLastError());
		closesocket(ListenSocket);
		WSACleanup();
		return 1;
	}

	// Accept a client socket
	ClientSocket = accept(ListenSocket, NULL, NULL);
	if (ClientSocket == INVALID_SOCKET) {
		printf("accept failed with error: %d\n", WSAGetLastError());
		closesocket(ListenSocket);
		WSACleanup();
		return 1;
	}

	// No longer need server socket
	closesocket(ListenSocket);

	// Receive until the peer shuts down the connection
	do {

		iResult = recv(ClientSocket, recvbuf, recvbuflen, 0);
		if (iResult > 0) {
			printf("Bytes received: %d\n", iResult);
			
			vecByte package = response(recvbuf, iResult);
			
			iSendResult = send(ClientSocket, (char*)&package[0], package.size(), 0);
			if (iSendResult == SOCKET_ERROR) {
				printf("send failed with error: %d\n", WSAGetLastError());
				closesocket(ClientSocket);
				WSACleanup();
				return 1;
			}
			printf("Bytes sent: %d\n", iSendResult);
		}
		else if (iResult == 0)
			printf("Connection closing...\n");
		else {
			printf("recv failed with error: %d\n", WSAGetLastError());
			closesocket(ClientSocket);
			WSACleanup();
			return 1;
		}

	} while (iResult > 0);

	// shutdown the connection since we're done
	iResult = shutdown(ClientSocket, SD_SEND);
	if (iResult == SOCKET_ERROR) {
		printf("shutdown failed with error: %d\n", WSAGetLastError());
		closesocket(ClientSocket);
		WSACleanup();
		return 1;
	}

	// cleanup
	closesocket(ClientSocket);
	WSACleanup();

	return 0;
}

