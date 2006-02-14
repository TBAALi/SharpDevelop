// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class CorDebugClass
	{
		
		private Debugger.Interop.CorDebug.CorDebugClass wrappedObject;
		
		internal Debugger.Interop.CorDebug.CorDebugClass WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public CorDebugClass(Debugger.Interop.CorDebug.CorDebugClass wrappedObject)
		{
			this.wrappedObject = wrappedObject;
			ResourceManager.TrackCOMObject(wrappedObject, typeof(CorDebugClass));
		}
		
		public static CorDebugClass Wrap(Debugger.Interop.CorDebug.CorDebugClass objectToWrap)
		{
			return new CorDebugClass(objectToWrap);
		}
		
		~CorDebugClass()
		{
			object o = wrappedObject;
			wrappedObject = null;
			ResourceManager.ReleaseCOMObject(o, typeof(CorDebugClass));
		}
		
		public bool Is<T>() where T: class
		{
			try {
				CastTo<T>();
				return true;
			} catch {
				return false;
			}
		}
		
		public T As<T>() where T: class
		{
			try {
				return CastTo<T>();
			} catch {
				return null;
			}
		}
		
		public T CastTo<T>() where T: class
		{
			return (T)Activator.CreateInstance(typeof(T), this.WrappedObject);
		}
		
		public static bool operator ==(CorDebugClass o1, CorDebugClass o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(CorDebugClass o1, CorDebugClass o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			CorDebugClass casted = o as CorDebugClass;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public void CanLaunchOrAttach(uint dwProcessId, int win32DebuggingEnabled)
		{
			this.WrappedObject.CanLaunchOrAttach(dwProcessId, win32DebuggingEnabled);
		}
		
		public ICorDebugProcess CreateProcess(string lpApplicationName, string lpCommandLine, ref Debugger.Interop.CorDebug._SECURITY_ATTRIBUTES lpProcessAttributes, ref Debugger.Interop.CorDebug._SECURITY_ATTRIBUTES lpThreadAttributes, int bInheritHandles, uint dwCreationFlags, System.IntPtr lpEnvironment, string lpCurrentDirectory, uint lpStartupInfo, uint lpProcessInformation, CorDebugCreateProcessFlags debuggingFlags)
		{
			ICorDebugProcess ppProcess;
			Debugger.Interop.CorDebug.ICorDebugProcess out_ppProcess;
			this.WrappedObject.CreateProcess(lpApplicationName, lpCommandLine, ref lpProcessAttributes, ref lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, lpStartupInfo, lpProcessInformation, ((Debugger.Interop.CorDebug.CorDebugCreateProcessFlags)(debuggingFlags)), out out_ppProcess);
			ppProcess = ICorDebugProcess.Wrap(out_ppProcess);
			return ppProcess;
		}
		
		public ICorDebugProcess DebugActiveProcess(uint id, int win32Attach)
		{
			ICorDebugProcess ppProcess;
			Debugger.Interop.CorDebug.ICorDebugProcess out_ppProcess;
			this.WrappedObject.DebugActiveProcess(id, win32Attach, out out_ppProcess);
			ppProcess = ICorDebugProcess.Wrap(out_ppProcess);
			return ppProcess;
		}
		
		public ICorDebugProcessEnum EnumerateProcesses()
		{
			ICorDebugProcessEnum ppProcess;
			Debugger.Interop.CorDebug.ICorDebugProcessEnum out_ppProcess;
			this.WrappedObject.EnumerateProcesses(out out_ppProcess);
			ppProcess = ICorDebugProcessEnum.Wrap(out_ppProcess);
			return ppProcess;
		}
		
		public ICorDebugProcess GetProcess(uint dwProcessId)
		{
			ICorDebugProcess ppProcess;
			Debugger.Interop.CorDebug.ICorDebugProcess out_ppProcess;
			this.WrappedObject.GetProcess(dwProcessId, out out_ppProcess);
			ppProcess = ICorDebugProcess.Wrap(out_ppProcess);
			return ppProcess;
		}
		
		public void Initialize()
		{
			this.WrappedObject.Initialize();
		}
		
		public void SetManagedHandler(ICorDebugManagedCallback pCallback)
		{
			this.WrappedObject.SetManagedHandler(pCallback.WrappedObject);
		}
		
		public void SetUnmanagedHandler(ICorDebugUnmanagedCallback pCallback)
		{
			this.WrappedObject.SetUnmanagedHandler(pCallback.WrappedObject);
		}
		
		public void Terminate()
		{
			this.WrappedObject.Terminate();
		}
	}
}
