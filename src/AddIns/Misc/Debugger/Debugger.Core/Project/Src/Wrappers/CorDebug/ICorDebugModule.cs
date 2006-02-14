// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugModule
	{
		
		private Debugger.Interop.CorDebug.ICorDebugModule wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugModule WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugModule(Debugger.Interop.CorDebug.ICorDebugModule wrappedObject)
		{
			this.wrappedObject = wrappedObject;
			ResourceManager.TrackCOMObject(wrappedObject, typeof(ICorDebugModule));
		}
		
		public static ICorDebugModule Wrap(Debugger.Interop.CorDebug.ICorDebugModule objectToWrap)
		{
			return new ICorDebugModule(objectToWrap);
		}
		
		~ICorDebugModule()
		{
			object o = wrappedObject;
			wrappedObject = null;
			ResourceManager.ReleaseCOMObject(o, typeof(ICorDebugModule));
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
		
		public static bool operator ==(ICorDebugModule o1, ICorDebugModule o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugModule o1, ICorDebugModule o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugModule casted = o as ICorDebugModule;
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
		
		public ulong BaseAddress
		{
			get
			{
				ulong pAddress;
				this.WrappedObject.GetBaseAddress(out pAddress);
				return pAddress;
			}
		}
		
		public ICorDebugAssembly Assembly
		{
			get
			{
				ICorDebugAssembly ppAssembly;
				Debugger.Interop.CorDebug.ICorDebugAssembly out_ppAssembly;
				this.WrappedObject.GetAssembly(out out_ppAssembly);
				ppAssembly = ICorDebugAssembly.Wrap(out_ppAssembly);
				return ppAssembly;
			}
		}
		
		public void GetName(uint cchName, out uint pcchName, System.IntPtr szName)
		{
			this.WrappedObject.GetName(cchName, out pcchName, szName);
		}
		
		public void EnableJITDebugging(int bTrackJITInfo, int bAllowJitOpts)
		{
			this.WrappedObject.EnableJITDebugging(bTrackJITInfo, bAllowJitOpts);
		}
		
		public void EnableClassLoadCallbacks(int bClassLoadCallbacks)
		{
			this.WrappedObject.EnableClassLoadCallbacks(bClassLoadCallbacks);
		}
		
		public ICorDebugFunction GetFunctionFromToken(uint methodDef)
		{
			ICorDebugFunction ppFunction;
			Debugger.Interop.CorDebug.ICorDebugFunction out_ppFunction;
			this.WrappedObject.GetFunctionFromToken(methodDef, out out_ppFunction);
			ppFunction = ICorDebugFunction.Wrap(out_ppFunction);
			return ppFunction;
		}
		
		public ICorDebugFunction GetFunctionFromRVA(ulong rva)
		{
			ICorDebugFunction ppFunction;
			Debugger.Interop.CorDebug.ICorDebugFunction out_ppFunction;
			this.WrappedObject.GetFunctionFromRVA(rva, out out_ppFunction);
			ppFunction = ICorDebugFunction.Wrap(out_ppFunction);
			return ppFunction;
		}
		
		public ICorDebugClass GetClassFromToken(uint typeDef)
		{
			ICorDebugClass ppClass;
			Debugger.Interop.CorDebug.ICorDebugClass out_ppClass;
			this.WrappedObject.GetClassFromToken(typeDef, out out_ppClass);
			ppClass = ICorDebugClass.Wrap(out_ppClass);
			return ppClass;
		}
		
		public ICorDebugModuleBreakpoint CreateBreakpoint()
		{
			ICorDebugModuleBreakpoint ppBreakpoint;
			Debugger.Interop.CorDebug.ICorDebugModuleBreakpoint out_ppBreakpoint;
			this.WrappedObject.CreateBreakpoint(out out_ppBreakpoint);
			ppBreakpoint = ICorDebugModuleBreakpoint.Wrap(out_ppBreakpoint);
			return ppBreakpoint;
		}
		
		public ICorDebugEditAndContinueSnapshot EditAndContinueSnapshot
		{
			get
			{
				ICorDebugEditAndContinueSnapshot ppEditAndContinueSnapshot;
				Debugger.Interop.CorDebug.ICorDebugEditAndContinueSnapshot out_ppEditAndContinueSnapshot;
				this.WrappedObject.GetEditAndContinueSnapshot(out out_ppEditAndContinueSnapshot);
				ppEditAndContinueSnapshot = ICorDebugEditAndContinueSnapshot.Wrap(out_ppEditAndContinueSnapshot);
				return ppEditAndContinueSnapshot;
			}
		}
		
		public object GetMetaDataInterface(ref System.Guid riid)
		{
			object ppObj;
			this.WrappedObject.GetMetaDataInterface(ref riid, out ppObj);
			return ppObj;
		}
		
		public uint Token
		{
			get
			{
				uint pToken;
				this.WrappedObject.GetToken(out pToken);
				return pToken;
			}
		}
		
		public int IsDynamic
		{
			get
			{
				int pDynamic;
				this.WrappedObject.IsDynamic(out pDynamic);
				return pDynamic;
			}
		}
		
		public ICorDebugValue GetGlobalVariableValue(uint fieldDef)
		{
			ICorDebugValue ppValue;
			Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
			this.WrappedObject.GetGlobalVariableValue(fieldDef, out out_ppValue);
			ppValue = ICorDebugValue.Wrap(out_ppValue);
			return ppValue;
		}
		
		public uint Size
		{
			get
			{
				uint pcBytes;
				this.WrappedObject.GetSize(out pcBytes);
				return pcBytes;
			}
		}
		
		public int IsInMemory
		{
			get
			{
				int pInMemory;
				this.WrappedObject.IsInMemory(out pInMemory);
				return pInMemory;
			}
		}
	}
}
