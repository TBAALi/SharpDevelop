// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugILFrame
	{
		
		private Debugger.Interop.CorDebug.ICorDebugILFrame wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugILFrame WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugILFrame(Debugger.Interop.CorDebug.ICorDebugILFrame wrappedObject)
		{
			this.wrappedObject = wrappedObject;
			ResourceManager.TrackCOMObject(wrappedObject, typeof(ICorDebugILFrame));
		}
		
		public static ICorDebugILFrame Wrap(Debugger.Interop.CorDebug.ICorDebugILFrame objectToWrap)
		{
			return new ICorDebugILFrame(objectToWrap);
		}
		
		~ICorDebugILFrame()
		{
			object o = wrappedObject;
			wrappedObject = null;
			ResourceManager.ReleaseCOMObject(o, typeof(ICorDebugILFrame));
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
		
		public static bool operator ==(ICorDebugILFrame o1, ICorDebugILFrame o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugILFrame o1, ICorDebugILFrame o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugILFrame casted = o as ICorDebugILFrame;
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
		
		public CorDebugMappingResult GetIP(out uint pnOffset)
		{
			CorDebugMappingResult pMappingResult;
			Debugger.Interop.CorDebug.CorDebugMappingResult out_pMappingResult;
			this.WrappedObject.GetIP(out pnOffset, out out_pMappingResult);
			pMappingResult = ((CorDebugMappingResult)(out_pMappingResult));
			return pMappingResult;
		}
		
		public void SetIP(uint nOffset)
		{
			this.WrappedObject.SetIP(nOffset);
		}
		
		public ICorDebugValueEnum EnumerateLocalVariables()
		{
			ICorDebugValueEnum ppValueEnum;
			Debugger.Interop.CorDebug.ICorDebugValueEnum out_ppValueEnum;
			this.WrappedObject.EnumerateLocalVariables(out out_ppValueEnum);
			ppValueEnum = ICorDebugValueEnum.Wrap(out_ppValueEnum);
			return ppValueEnum;
		}
		
		public ICorDebugValue GetLocalVariable(uint dwIndex)
		{
			ICorDebugValue ppValue;
			Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
			this.WrappedObject.GetLocalVariable(dwIndex, out out_ppValue);
			ppValue = ICorDebugValue.Wrap(out_ppValue);
			return ppValue;
		}
		
		public ICorDebugValueEnum EnumerateArguments()
		{
			ICorDebugValueEnum ppValueEnum;
			Debugger.Interop.CorDebug.ICorDebugValueEnum out_ppValueEnum;
			this.WrappedObject.EnumerateArguments(out out_ppValueEnum);
			ppValueEnum = ICorDebugValueEnum.Wrap(out_ppValueEnum);
			return ppValueEnum;
		}
		
		public ICorDebugValue GetArgument(uint dwIndex)
		{
			ICorDebugValue ppValue;
			Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
			this.WrappedObject.GetArgument(dwIndex, out out_ppValue);
			ppValue = ICorDebugValue.Wrap(out_ppValue);
			return ppValue;
		}
		
		public uint StackDepth
		{
			get
			{
				uint pDepth;
				this.WrappedObject.GetStackDepth(out pDepth);
				return pDepth;
			}
		}
		
		public ICorDebugValue GetStackValue(uint dwIndex)
		{
			ICorDebugValue ppValue;
			Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
			this.WrappedObject.GetStackValue(dwIndex, out out_ppValue);
			ppValue = ICorDebugValue.Wrap(out_ppValue);
			return ppValue;
		}
		
		public void CanSetIP(uint nOffset)
		{
			this.WrappedObject.CanSetIP(nOffset);
		}
	}
}
