// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugType
	{
		
		private Debugger.Interop.CorDebug.ICorDebugType wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugType WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugType(Debugger.Interop.CorDebug.ICorDebugType wrappedObject)
		{
			this.wrappedObject = wrappedObject;
			ResourceManager.TrackCOMObject(wrappedObject, typeof(ICorDebugType));
		}
		
		public static ICorDebugType Wrap(Debugger.Interop.CorDebug.ICorDebugType objectToWrap)
		{
			return new ICorDebugType(objectToWrap);
		}
		
		~ICorDebugType()
		{
			object o = wrappedObject;
			wrappedObject = null;
			ResourceManager.ReleaseCOMObject(o, typeof(ICorDebugType));
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
		
		public static bool operator ==(ICorDebugType o1, ICorDebugType o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugType o1, ICorDebugType o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugType casted = o as ICorDebugType;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public uint Type
		{
			get
			{
				uint ty;
				this.WrappedObject.GetType(out ty);
				return ty;
			}
		}
		
		public ICorDebugClass Class
		{
			get
			{
				ICorDebugClass ppClass;
				Debugger.Interop.CorDebug.ICorDebugClass out_ppClass;
				this.WrappedObject.GetClass(out out_ppClass);
				ppClass = ICorDebugClass.Wrap(out_ppClass);
				return ppClass;
			}
		}
		
		public ICorDebugTypeEnum EnumerateTypeParameters()
		{
			ICorDebugTypeEnum ppTyParEnum;
			Debugger.Interop.CorDebug.ICorDebugTypeEnum out_ppTyParEnum;
			this.WrappedObject.EnumerateTypeParameters(out out_ppTyParEnum);
			ppTyParEnum = ICorDebugTypeEnum.Wrap(out_ppTyParEnum);
			return ppTyParEnum;
		}
		
		public ICorDebugType FirstTypeParameter
		{
			get
			{
				ICorDebugType value;
				Debugger.Interop.CorDebug.ICorDebugType out_value;
				this.WrappedObject.GetFirstTypeParameter(out out_value);
				value = ICorDebugType.Wrap(out_value);
				return value;
			}
		}
		
		public ICorDebugType Base
		{
			get
			{
				ICorDebugType pBase;
				Debugger.Interop.CorDebug.ICorDebugType out_pBase;
				this.WrappedObject.GetBase(out out_pBase);
				pBase = ICorDebugType.Wrap(out_pBase);
				return pBase;
			}
		}
		
		public ICorDebugValue GetStaticFieldValue(uint fieldDef, ICorDebugFrame pFrame)
		{
			ICorDebugValue ppValue;
			Debugger.Interop.CorDebug.ICorDebugValue out_ppValue;
			this.WrappedObject.GetStaticFieldValue(fieldDef, pFrame.WrappedObject, out out_ppValue);
			ppValue = ICorDebugValue.Wrap(out_ppValue);
			return ppValue;
		}
		
		public uint Rank
		{
			get
			{
				uint pnRank;
				this.WrappedObject.GetRank(out pnRank);
				return pnRank;
			}
		}
	}
}
