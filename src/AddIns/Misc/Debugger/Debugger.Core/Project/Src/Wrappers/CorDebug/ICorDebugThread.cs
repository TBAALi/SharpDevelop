// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugThread
	{
		
		private Debugger.Interop.CorDebug.ICorDebugThread wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugThread WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugThread(Debugger.Interop.CorDebug.ICorDebugThread wrappedObject)
		{
			this.wrappedObject = wrappedObject;
			ResourceManager.TrackCOMObject(wrappedObject, typeof(ICorDebugThread));
		}
		
		public static ICorDebugThread Wrap(Debugger.Interop.CorDebug.ICorDebugThread objectToWrap)
		{
			return new ICorDebugThread(objectToWrap);
		}
		
		~ICorDebugThread()
		{
			object o = wrappedObject;
			wrappedObject = null;
			ResourceManager.ReleaseCOMObject(o, typeof(ICorDebugThread));
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
		
		public static bool operator ==(ICorDebugThread o1, ICorDebugThread o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugThread o1, ICorDebugThread o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugThread casted = o as ICorDebugThread;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
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
		
		public uint ID
		{
			get
			{
				uint pdwThreadId;
				this.WrappedObject.GetID(out pdwThreadId);
				return pdwThreadId;
			}
		}
		
		public uint Handle
		{
			get
			{
				uint phThreadHandle;
				this.WrappedObject.GetHandle(out phThreadHandle);
				return phThreadHandle;
			}
		}
		
		public ICorDebugAppDomain AppDomain
		{
			get
			{
				ICorDebugAppDomain ppAppDomain;
				Debugger.Interop.CorDebug.ICorDebugAppDomain out_ppAppDomain;
				this.WrappedObject.GetAppDomain(out out_ppAppDomain);
				ppAppDomain = ICorDebugAppDomain.Wrap(out_ppAppDomain);
				return ppAppDomain;
			}
		}
		
		public void SetDebugState(CorDebugThreadState state)
		{
			this.WrappedObject.SetDebugState(((Debugger.Interop.CorDebug.CorDebugThreadState)(state)));
		}
		
		public CorDebugThreadState DebugState
		{
			get
			{
				CorDebugThreadState pState;
				Debugger.Interop.CorDebug.CorDebugThreadState out_pState;
				this.WrappedObject.GetDebugState(out out_pState);
				pState = ((CorDebugThreadState)(out_pState));
				return pState;
			}
		}
		
		public CorDebugUserState UserState
		{
			get
			{
				CorDebugUserState pState;
				Debugger.Interop.CorDebug.CorDebugUserState out_pState;
				this.WrappedObject.GetUserState(out out_pState);
				pState = ((CorDebugUserState)(out_pState));
				return pState;
			}
		}
		
		public ICorDebugValue CurrentException
		{
			get
			{
				ICorDebugValue ppExceptionObject;
				Debugger.Interop.CorDebug.ICorDebugValue out_ppExceptionObject;
				this.WrappedObject.GetCurrentException(out out_ppExceptionObject);
				ppExceptionObject = ICorDebugValue.Wrap(out_ppExceptionObject);
				return ppExceptionObject;
			}
		}
		
		public void ClearCurrentException()
		{
			this.WrappedObject.ClearCurrentException();
		}
		
		public ICorDebugStepper CreateStepper()
		{
			ICorDebugStepper ppStepper;
			Debugger.Interop.CorDebug.ICorDebugStepper out_ppStepper;
			this.WrappedObject.CreateStepper(out out_ppStepper);
			ppStepper = ICorDebugStepper.Wrap(out_ppStepper);
			return ppStepper;
		}
		
		public ICorDebugChainEnum EnumerateChains()
		{
			ICorDebugChainEnum ppChains;
			Debugger.Interop.CorDebug.ICorDebugChainEnum out_ppChains;
			this.WrappedObject.EnumerateChains(out out_ppChains);
			ppChains = ICorDebugChainEnum.Wrap(out_ppChains);
			return ppChains;
		}
		
		public ICorDebugChain ActiveChain
		{
			get
			{
				ICorDebugChain ppChain;
				Debugger.Interop.CorDebug.ICorDebugChain out_ppChain;
				this.WrappedObject.GetActiveChain(out out_ppChain);
				ppChain = ICorDebugChain.Wrap(out_ppChain);
				return ppChain;
			}
		}
		
		public ICorDebugFrame ActiveFrame
		{
			get
			{
				ICorDebugFrame ppFrame;
				Debugger.Interop.CorDebug.ICorDebugFrame out_ppFrame;
				this.WrappedObject.GetActiveFrame(out out_ppFrame);
				ppFrame = ICorDebugFrame.Wrap(out_ppFrame);
				return ppFrame;
			}
		}
		
		public ICorDebugRegisterSet RegisterSet
		{
			get
			{
				ICorDebugRegisterSet ppRegisters;
				Debugger.Interop.CorDebug.ICorDebugRegisterSet out_ppRegisters;
				this.WrappedObject.GetRegisterSet(out out_ppRegisters);
				ppRegisters = ICorDebugRegisterSet.Wrap(out_ppRegisters);
				return ppRegisters;
			}
		}
		
		public ICorDebugEval CreateEval()
		{
			ICorDebugEval ppEval;
			Debugger.Interop.CorDebug.ICorDebugEval out_ppEval;
			this.WrappedObject.CreateEval(out out_ppEval);
			ppEval = ICorDebugEval.Wrap(out_ppEval);
			return ppEval;
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
	}
}
