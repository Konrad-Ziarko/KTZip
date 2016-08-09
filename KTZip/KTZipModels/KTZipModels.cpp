// This is the main DLL file.

#include "stdafx.h"
#include "KTZipModels.h"

using namespace KTZipModels;

FileInfoGeter::FileInfoGeter(char* filename) {
	fileName = filename;
}

long FileInfoGeter::GetFileSize()
{
	try {
		struct stat stat_buf;
		int rc = stat(fileName, &stat_buf);
		return rc == 0 ? stat_buf.st_size : -1;
	}
	catch (...) {
		return -1;
	}
}
char* FileInfoGeter::GetCeationAndLastWriteTime() {
	FILETIME creationTime, lpLastAccessTime, lastWriteTime;
	const char * cs = fileName;
	size_t wn = mbsrtowcs(NULL, &cs, 0, NULL);
	wchar_t * buf = new wchar_t[wn + 1]();
	wn = mbsrtowcs(buf, &cs, wn + 1, NULL);
	HANDLE h = CreateFile(buf, GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL | FILE_FLAG_OVERLAPPED, NULL);
	delete[] buf;
	BOOL err = GetFileTime(h, &creationTime, &lpLastAccessTime, &lastWriteTime);
	if (!err) {
		SYSTEMTIME now, systemTimeCreate, systemTimeModify;
		BOOL res1 = FileTimeToSystemTime(&creationTime, &systemTimeCreate);
		BOOL res2 = FileTimeToSystemTime(&creationTime, &systemTimeModify);
		GetLocalTime(&now);
		std::ostringstream toReturn;
		if (!res1) {
			if (now.wDay == systemTimeCreate.wDay && now.wMonth == systemTimeCreate.wMonth && now.wYear == systemTimeCreate.wYear) {
				toReturn << std::setw(2) << std::setfill('0') << systemTimeCreate.wHour << ":"
					<< std::setw(2) << std::setfill('0') << systemTimeCreate.wMinute << ":"
					<< std::setw(2) << std::setfill('0') << systemTimeCreate.wSecond;
			}
			else {
				toReturn << systemTimeCreate.wDay << "-"
					<< std::setw(2) << std::setfill('0') << systemTimeCreate.wMonth << "-"
					<< std::setw(2) << std::setfill('0') << systemTimeCreate.wYear;
			}
		}
		if (!res1 && !res2)
			toReturn << "?";
		if (!res2) {
			if (now.wDay == systemTimeModify.wDay && now.wMonth == systemTimeModify.wMonth && now.wYear == systemTimeModify.wYear) {
				toReturn << std::setw(2) << std::setfill('0') << systemTimeModify.wHour << ":"
					<< std::setw(2) << std::setfill('0') << systemTimeModify.wMinute << ":"
					<< std::setw(2) << std::setfill('0') << systemTimeModify.wSecond;
			}
			else {
				toReturn << systemTimeModify.wDay << "-"
					<< std::setw(2) << std::setfill('0') << systemTimeModify.wMonth << "-"
					<< std::setw(2) << std::setfill('0') << systemTimeModify.wYear;
			}
		}
		return strdup(toReturn.str().c_str());
	}
	else
		return "";
}
