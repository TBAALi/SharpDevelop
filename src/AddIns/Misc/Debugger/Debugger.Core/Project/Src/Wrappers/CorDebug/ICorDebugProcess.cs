// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugProcess
	{
		
		private Debugger.Interop.CorDebug.ICorDebugProcess wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugProcess WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugProcess(Debugger.Interop.CorDebug.ICorDebugProcess wrappedObject)
		{
			this.wrappedObject = wrappedObject;
			ResourceManager.TrackCOMObject(wrappedObject, typeof(ICorDebugProcess));
		}
		
		public static ICorDebugProcess Wrap(Debugger.Interop.CorDebug.ICorDebugProcess objectToWrap)
		{
			return new ICorDebugProcess(objectToWrap);
		}
		
		~ICorDebugProcess()
		{
			object o = wrappedObject;
			wrappedObject = null;
			ResourceManager.ReleaseCOMObject(o, typeof(ICorDebugProcess));
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
		
		public static bool operator ==(ICorDebugProcess o1, ICorDebugProcess o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugProcess o1, ICorDebugProcess o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugProcess casted = o as ICorDebugProcess;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public void Stop(uint dwTimeoutIgnored)
		{
			this.WrappedObject.Stop(dwTimeoutIgnored);
		}
		
		public void Continue(int fIsOutOfBand)
		{
			this.WrappedObject.Continue(fIsOutOfBand);
		}
		
		public int IsRunning
		{
			get
			{
				int pbRunning;
				this.WrappedObject.IsRunning(out pbRunning);
				return pbRunning;
			}
		}
		
		public int HasQueuedCallbacks(ICorDebugThread pThread)
		{
			int pbQueued;
			this.WrappedObject.HasQueuedCallbacks(pThread.WrappedObject, out pbQueued);
			return pbQueued;
		}
		
		public ICorDebugThreadEnum EnumerateThreads()
		{
			ICorDebugThreadEnum ppThreads;
			Debugger.Interop.CorDebug.ICorDebugThreadEnum out_ppThreads;
			this.WrappedObject.EnumerateThreads(out out_ppThreads);
			ppThreads = ICorDebugThreadEnum.Wrap(out_ppThreads);
			return ppThreads;
		}
		
		public void SetAllThreadsDebugState(CorDebugThreadState state, ICorDebugThread pExceptThisThread)
		{
			this.WrappedObject.SetAllThreadsDebugState(((Debugger.Interop.CorDebug.CorDebugThreadState)(state)), pExceptThisThread.WrappedObject);
		}
		
		public void Detach()
		{
			this.WrappedObject.Detach();
		}
		
		public void Terminate(uint exitCode)
		{
			this.WrappedObject.Terminate(exitCode);
		}
		
		public ICorDebugErrorInfoEnum CanCommitChanges(uint cSnapshots, ref ICorDebugEditAndContinueSnapshot pSnapshots)
		{
			ICorDebugErrorInfoEnum pError;
			Debugger.Interop.CorDebug.ICorDebugEditAndContinueSnapshot ref_pSnapshots = pSnapshots.WrappedObject;
			Debugger.Interop.CorDebug.ICorDebugErrorInfoEnum out_pError;
			this.WrappedObject.CanCommitChanges(cSnapshots, ref ref_pSnapshots, out out_pError);
			pSnapshots = ICorDebugEditAndContinueSnapshot.Wrap(ref_pSnapshots);
			pError = ICorDebugErrorInfoEnum.Wrap(out_pError);
			return pError;
		}
		
		public ICorDebugErrorInfoEnum CommitChanges(uint cSnapshots, ref ICorDebugEditAndContinueSnapshot pSnapshots)
		{
			ICorDebugErrorInfoEnum pError;
			Debugger.Interop.CorDebug.ICorDebugEditAndContinueSnapshot ref_pSnapshots = pSnapshots.WrappedObject;
			Debugger.Interop.CorDebug.ICorDebugErrorInfoEnum out_pError;
			this.WrappedObject.CommitChanges(cSnapshots, ref ref_pSnapshots, out out_pError);
			pSnapshots = ICorDebugEditAndContinueSnapshot.Wrap(ref_pSnapshots);
			pError = ICorDebugErrorInfoEnum.Wrap(out_pError);
			return pError;
		}
		
		public uint ID
		{
			get
			{
				uint pdwProcessId;
				this.WrappedObject.GetID(out pdwProcessId);
				return pdwProcessId;
			}
		}
		
		public uint Handle
		{
			get
			{
				uint phProcessHandle;
				this.WrappedObject.GetHandle(out phProcessHandle);
				return phProcessHandle;
			}
		}
		
		public ICorDebugThread GetThread(uint dwThreadId)
		{
			ICorDebugThread ppThread;
			Debugger.Interop.CorDebug.ICorDebugThread out_ppThread;
			this.WrappedObject.GetThread(dwThreadId, out out_ppThread);
			ppThread = ICorDebugThread.Wrap(out_ppThread);
			return ppThread;
		}
		
		public ICorDebugObjectEnum EnumerateObjects()
		{
			ICorDebugObjectEnum ppObjects;
			Debugger.Interop.CorDebug.ICorDebugObjectEnum out_ppObjects;
			this.WrappedObject.EnumerateObjects(out out_ppObjects);
			ppObjects = ICorDebugObjectEnum.Wrap(out_ppObjects);
			return ppObjects;
		}
		
		public int IsTransitionStub(ulong address)
		{
			int pbTransitionStub;
			this.WrappedObject.IsTransitionStub(address, out pbTransitionStub);
			return pbTransitionStub;
		}
		
		public int IsOSSuspended(uint threadID)
		{
			int pbSuspended;
			this.WrappedObject.IsOSSuspended(threadID, out pbSuspended);
			return pbSuspended;
		}
		
		public void GetThreadContext(uint threadID, uint contextSize, System.IntPtr context)
		{
			this.WrappedObject.GetThreadContext(threadID, contextSize, context);
		}
		
		public void SetThreadContext(uint threadID, uint contextSize, System.IntPtr context)
		{
			this.WrappedObject.SetThreadContext(threadID, contextSize, context);
		}
		
		public uint ReadMemory(ulong address, uint size, System.IntPtr buffer)
		{
			uint read;
			this.WrappedObject.ReadMemory(address, size, buffer, out read);
			return read;
		}
		
		public uint WriteMemory(ulong address, uint size, ref byte buffer)
		{
			uint written;
			this.WrappedObject.WriteMemory(address, size, ref buffer, out written);
			return written;
		}
		
		public void ClearCurrentException(uint threadID)
		{
			this.WrappedObject.ClearCurrentException(threadID);
		}
		
		public void EnableLogMessages(int fOnOff)
		{
			this.WrappedObject.EnableLogMessages(fOnOff);
		}
		
		public void ModifyLogSwitch(ref ushort pLogSwitchName, int lLevel)
		{
			this.WrappedObject.ModifyLogSwitch(ref pLogSwitchName, lLevel);
		}
		
		public ICorDebugAppDomainEnum EnumerateAppDomains()
		{
			ICorDebugAppDomainEnum ppAppDomains;
			Debugger.Interop.CorDebug.ICorDebugAppDomainEnum out_ppAppDomains;
			this.WrappedObject.EnumerateAppDomains(out out_ppAppDomains);
			ppAppDomains = ICorDebugAppDomainEnum.Wrap(out_ppAppDomains);
			return ppAppDomains;
		}
		
		public ICorDebugValue Object
		{
			get
			{
				ICorDebugValue ppObject;
				Debugger.Interop.CorDebug.ICorDebugValue out_ppObject;
				this.WrappedObject.GetObject(out out_ppObject);
				ppObject = ICorDebugValue.Wrap(out_ppObject);
				return ppObject;
			}
		}
		
		public ICorDebugThread ThreadForFiberCookie(uint fiberCookie)
		{
			ICorDebugThread ppThread;
			Debugger.Interop.CorDebug.ICorDebugThread out_ppThread;
			this.WrappedObject.ThreadForFiberCookie(fiberCookie, out out_ppThread);
			ppThread = ICorDebugThread.Wrap(out_ppThread);
			return ppThread;
		}
		
		public uint HelperThreadID
		{
			get
			{
				uint pThreadID;
				this.WrappedObject.GetHelperThreadID(out pThreadID);
				return pThreadID;
			}
		}
	}
}
