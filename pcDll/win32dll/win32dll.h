typedef void (_stdcall *pVoidFun)(int, int);
extern "C" __declspec(dllexport) void _stdcall setCallBack(pVoidFun fun);
extern "C" __declspec(dllexport) int _stdcall runCapture();
