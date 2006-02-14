// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugNativeFrame
	{
		
		private Debugger.Interop.CorDebug.ICorDebugNativeFrame wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugNativeFrame WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugNativeFrame(Debugger.Interop.CorDebug.ICorDebugNativeFrame wrappedObject)
		{
			this.wrappedObject = wrappedObject;
			ResourceManager.TrackCOMObject(wrappedObject, typeof(ICorDebugNativeFrame));
		}
		
		public static ICorDebugNativeFrame Wrap(Debugger.Interop.CorDebug.ICorDebugNativeFrame objectToWrap)
		{
			return new ICorDebugNativeFrame(objectToWrap);
		}
		
		~ICorDebugNativeFrame()
		{
			object o = wrappedObject;
			wrappedObject = null;
			ResourceManager.ReleaseCOMObject(o, typeof(ICorDebugNativeFrame));
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
		
		public static bool operator ==(ICorDebugNativeFrame o1, ICorDebugNativeFrame o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugNativeFrame o1, ICorDebugNativeFrame o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugNativeFrame casted = o as ICorDebugNativeFrame;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public ICorDebugChain Chain
		{
			get
			{
				ICorDebugChain ppChain;
				Debugger.Interop.CorDebug.ICorDebugChain out_ppChain;
				this.WrappedObject.GetChain(out out_ppChain);
				ppChain = ICorDebugChain.Wrap(out_ppChain);
				return ppChain;
			}
		}
		
		public ICorDebugCode Code
		{
			get
			{
				ICorDebugCode ppCode;
				Debugger.Interop.CorDebug.ICorDebugCode out_ppCode;
				this.WrappedObject.GetCode(out out_ppCode);
				ppCode = ICorDebugCode.Wrap(out_ppCode);
				return ppCode;
			}
		}
		
		public ICorDebugFunction Function
		{
			get
			{
				ICorDebugFunction ppFunction;
				Debugger.Interop.CorDebug.ICorDebugFunction out_ppFunction;
				this.WrappedObject.GetFunction(out out_ppFunction);
				ppFunction = ICorDebugFunction.Wrap(out_ppFunction);
				return ppFunction;
			}
		}
		
		public uint FunctionToken
		{
			get
			{
				uint pToken;
				this.WrappedObject.GetFunctionToken(out pToken);
				return pToken;
			}
		}
		
		public ulong GetStackRange(out ulong pStart)
		{
			ulong pEnd;
			this.WrappedObject.GetStackRange(out pStart, out pEnd);
			return pEnd;
		}
		
		public ICorDebugFrame Caller
		{
			get
			{
				ICorDebugFrame ppFrame;
				Debugger.Interop.CorDebug.ICorDebugFrame out_ppFrame;
				this.WrappedObject.GetCaller(out out_ppFrame);
				ppFrame = ICorDebugFrame.Wrap(out_ppFrame);
				return ppFrame;
			}
		}
		
		public ICorDebugFrame Callee
		{
			get
			{
				ICorDebugFrame ppFrame;
				Debugger.Interop.CorDebug.ICorDebugFrame out_ppFrame;
				this.WrappedObject.GetCallee(out out_ppFrame);
				ppFrame = ICorDebugFrame.Wrap(out_ppFrame);
				return ppFrame;
			}
		}
		
		public ICorDebugStepper CreateStepper()
		{
			ICorDebugStepper ppStepper;
			Debugger.Interop.CorDebug.ICorDebugStepper out_ppStepper;
			this.WrappedObject.CreateStepper(out out_ppStepper);
			ppStepper = ICorDebugStepper.Wrap(out_ppStepper);
			return ppStepper;
		}
		
		public uint IP
		{
			get
			{
				uint pnOffset;
				this.WrappedObject.GetIP(out pnOffset);
				return pnOffset;
			}
		}
		
		public void SetIP(uint nOffset)
		{
			this.WrappedObject.SetIP(nOffset);
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
		
		public ICorDebugValue GetLocalRegisterValue(CorDebugRegister reg, uint cbSigBlob, uint pvSigBlob)
		{
			ICorDebugValue ppValue;
			Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
			this.WrappedObject.GetLocalRegisterValue(((Debugger.Interop.CorDebug.CorDebugRegister)(reg)), cbSigBlob, pvSigBlob, out out_ppValue);
			ppValue = ICorDebugValue.Wrap(out_ppValue);
			return ppValue;
		}
		
		public ICorDebugValue GetLocalDoubleRegisterValue(CorDebugRegister highWordReg, CorDebugRegister lowWordReg, uint cbSigBlob, uint pvSigBlob)
		{
			ICorDebugValue ppValue;
			Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
			this.WrappedObject.GetLocalDoubleRegisterValue(((Debugger.Interop.CorDebug.CorDebugRegister)(highWordReg)), ((Debugger.Interop.CorDebug.CorDebugRegister)(lowWordReg)), cbSigBlob, pvSigBlob, out out_ppValue);
			ppValue = ICorDebugValue.Wrap(out_ppValue);
			return ppValue;
		}
		
		public ICorDebugValue GetLocalMemoryValue(ulong address, uint cbSigBlob, uint pvSigBlob)
		{
			ICorDebugValue ppValue;
			Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
			this.WrappedObject.GetLocalMemoryValue(address, cbSigBlob, pvSigBlob, out out_ppValue);
			ppValue = ICorDebugValue.Wrap(out_ppValue);
			return ppValue;
		}
		
		public ICorDebugValue GetLocalRegisterMemoryValue(CorDebugRegister highWordReg, ulong lowWordAddress, uint cbSigBlob, uint pvSigBlob)
		{
			ICorDebugValue ppValue;
			Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
			this.WrappedObject.GetLocalRegisterMemoryValue(((Debugger.Interop.CorDebug.CorDebugRegister)(highWordReg)), lowWordAddress, cbSigBlob, pvSigBlob, out out_ppValue);
			ppValue = ICorDebugValue.Wrap(out_ppValue);
			return ppValue;
		}
		
		public ICorDebugValue GetLocalMemoryRegisterValue(ulong highWordAddress, CorDebugRegister lowWordRegister, uint cbSigBlob, uint pvSigBlob)
		{
			ICorDebugValue ppValue;
			Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
			this.WrappedObject.GetLocalMemoryRegisterValue(highWordAddress, ((Debugger.Interop.CorDebug.CorDebugRegister)(lowWordRegister)), cbSigBlob, pvSigBlob, out out_ppValue);
			ppValue = ICorDebugValue.Wrap(out_ppValue);
			return ppValue;
		}
		
		public void CanSetIP(uint nOffset)
		{
			this.WrappedObject.CanSetIP(nOffset);
		}
	}
}
