// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public class ICorDebugStepper
	{
		
		private Debugger.Interop.CorDebug.ICorDebugStepper wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugStepper WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugStepper(Debugger.Interop.CorDebug.ICorDebugStepper wrappedObject)
		{
			this.wrappedObject = wrappedObject;
			ResourceManager.TrackCOMObject(wrappedObject, typeof(ICorDebugStepper));
		}
		
		public static ICorDebugStepper Wrap(Debugger.Interop.CorDebug.ICorDebugStepper objectToWrap)
		{
			return new ICorDebugStepper(objectToWrap);
		}
		
		~ICorDebugStepper()
		{
			object o = wrappedObject;
			wrappedObject = null;
			ResourceManager.ReleaseCOMObject(o, typeof(ICorDebugStepper));
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
		
		public static bool operator ==(ICorDebugStepper o1, ICorDebugStepper o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugStepper o1, ICorDebugStepper o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugStepper casted = o as ICorDebugStepper;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public int IsActive
		{
			get
			{
				int pbActive;
				this.WrappedObject.IsActive(out pbActive);
				return pbActive;
			}
		}
		
		public void Deactivate()
		{
			this.WrappedObject.Deactivate();
		}
		
		public void SetInterceptMask(CorDebugIntercept mask)
		{
			this.WrappedObject.SetInterceptMask(((Debugger.Interop.CorDebug.CorDebugIntercept)(mask)));
		}
		
		public void SetUnmappedStopMask(CorDebugUnmappedStop mask)
		{
			this.WrappedObject.SetUnmappedStopMask(((Debugger.Interop.CorDebug.CorDebugUnmappedStop)(mask)));
		}
		
		public void Step(int bStepIn)
		{
			this.WrappedObject.Step(bStepIn);
		}
		
		public void StepRange(int bStepIn, System.IntPtr ranges, uint cRangeCount)
		{
			this.WrappedObject.StepRange(bStepIn, ranges, cRangeCount);
		}
		
		public void StepOut()
		{
			this.WrappedObject.StepOut();
		}
		
		public void SetRangeIL(int bIL)
		{
			this.WrappedObject.SetRangeIL(bIL);
		}
	}
}
