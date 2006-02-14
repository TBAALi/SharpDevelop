// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugClass
	{
		
		private Debugger.Interop.CorDebug.ICorDebugClass wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugClass WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugClass(Debugger.Interop.CorDebug.ICorDebugClass wrappedObject)
		{
			this.wrappedObject = wrappedObject;
			ResourceManager.TrackCOMObject(wrappedObject, typeof(ICorDebugClass));
		}
		
		public static ICorDebugClass Wrap(Debugger.Interop.CorDebug.ICorDebugClass objectToWrap)
		{
			return new ICorDebugClass(objectToWrap);
		}
		
		~ICorDebugClass()
		{
			object o = wrappedObject;
			wrappedObject = null;
			ResourceManager.ReleaseCOMObject(o, typeof(ICorDebugClass));
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
		
		public static bool operator ==(ICorDebugClass o1, ICorDebugClass o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugClass o1, ICorDebugClass o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugClass casted = o as ICorDebugClass;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public ICorDebugModule Module
		{
			get
			{
				ICorDebugModule pModule;
				Debugger.Interop.CorDebug.ICorDebugModule out_pModule;
				this.WrappedObject.GetModule(out out_pModule);
				pModule = ICorDebugModule.Wrap(out_pModule);
				return pModule;
			}
		}
		
		public uint Token
		{
			get
			{
				uint pTypeDef;
				this.WrappedObject.GetToken(out pTypeDef);
				return pTypeDef;
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
	}
}
