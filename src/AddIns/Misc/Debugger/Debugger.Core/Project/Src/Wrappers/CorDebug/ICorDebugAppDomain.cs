// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugAppDomain
	{
		
		private Debugger.Interop.CorDebug.ICorDebugAppDomain wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugAppDomain WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugAppDomain(Debugger.Interop.CorDebug.ICorDebugAppDomain wrappedObject)
		{
			this.wrappedObject = wrappedObject;
			ResourceManager.TrackCOMObject(wrappedObject, typeof(ICorDebugAppDomain));
		}
		
		public static ICorDebugAppDomain Wrap(Debugger.Interop.CorDebug.ICorDebugAppDomain objectToWrap)
		{
			return new ICorDebugAppDomain(objectToWrap);
		}
		
		~ICorDebugAppDomain()
		{
			object o = wrappedObject;
			wrappedObject = null;
			ResourceManager.ReleaseCOMObject(o, typeof(ICorDebugAppDomain));
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
		
		public static bool operator ==(ICorDebugAppDomain o1, ICorDebugAppDomain o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugAppDomain o1, ICorDebugAppDomain o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugAppDomain casted = o as ICorDebugAppDomain;
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
		
		public ICorDebugProcess Process
		{
			get
			{
				ICorDebugProcess ppProcess;
				Debugger.Interop.CorDebug.ICorDebugProcess out_ppProcess;
				this.WrappedObject.GetProcess(out out_ppProcess);
				ppProcess = ICorDebugProcess.Wrap(out_ppProcess);
				return ppProcess;
			}
		}
		
		public ICorDebugAssemblyEnum EnumerateAssemblies()
		{
			ICorDebugAssemblyEnum ppAssemblies;
			Debugger.Interop.CorDebug.ICorDebugAssemblyEnum out_ppAssemblies;
			this.WrappedObject.EnumerateAssemblies(out out_ppAssemblies);
			ppAssemblies = ICorDebugAssemblyEnum.Wrap(out_ppAssemblies);
			return ppAssemblies;
		}
		
		public ICorDebugModule GetModuleFromMetaDataInterface(object pIMetaData)
		{
			ICorDebugModule ppModule;
			Debugger.Interop.CorDebug.ICorDebugModule out_ppModule;
			this.WrappedObject.GetModuleFromMetaDataInterface(pIMetaData, out out_ppModule);
			ppModule = ICorDebugModule.Wrap(out_ppModule);
			return ppModule;
		}
		
		public ICorDebugBreakpointEnum EnumerateBreakpoints()
		{
			ICorDebugBreakpointEnum ppBreakpoints;
			Debugger.Interop.CorDebug.ICorDebugBreakpointEnum out_ppBreakpoints;
			this.WrappedObject.EnumerateBreakpoints(out out_ppBreakpoints);
			ppBreakpoints = ICorDebugBreakpointEnum.Wrap(out_ppBreakpoints);
			return ppBreakpoints;
		}
		
		public ICorDebugStepperEnum EnumerateSteppers()
		{
			ICorDebugStepperEnum ppSteppers;
			Debugger.Interop.CorDebug.ICorDebugStepperEnum out_ppSteppers;
			this.WrappedObject.EnumerateSteppers(out out_ppSteppers);
			ppSteppers = ICorDebugStepperEnum.Wrap(out_ppSteppers);
			return ppSteppers;
		}
		
		public int IsAttached
		{
			get
			{
				int pbAttached;
				this.WrappedObject.IsAttached(out pbAttached);
				return pbAttached;
			}
		}
		
		public void GetName(uint cchName, out uint pcchName, System.IntPtr szName)
		{
			this.WrappedObject.GetName(cchName, out pcchName, szName);
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
		
		public void Attach()
		{
			this.WrappedObject.Attach();
		}
		
		public uint ID
		{
			get
			{
				uint pId;
				this.WrappedObject.GetID(out pId);
				return pId;
			}
		}
	}
}
