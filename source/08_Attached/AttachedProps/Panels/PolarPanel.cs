using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AttachedProps
{
	public class PolarPanel : Panel
	{


		/// <summary>
		/// 
		/// Gets or sets a value indicating 
		/// whether Angle 0 is considered to be the
		/// X axis (to the right), or Y axis 
		/// (to the top).
		/// 
		/// original idea from Silverlight community
		/// <para>
		/// Note that this property is not 
		/// bindable, as it is not
		/// a Dependency Property.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The Polar Axis is a semi-infinite 
		/// ray from the Origin. This is generally
		/// set to be the X-Axis...but is preferred
		/// by some to be be the Y-Axis.
		/// </para>
		/// </remarks>
		/// <value>
		/// <c>true</c> if angle 0 is at the top; 
		/// otherwise, <c>false</c>.
		/// </value>
		public bool AngleFromTop
		{
			get { return _AngleFromTop; }
			set
			{
				if (value != _AngleFromTop)
				{
					_AngleFromTop = value;
					this.InvalidateArrange();
				}
			}
		}
		private bool _AngleFromTop = true;


		#region Attached Property - Angle
		public static readonly DependencyProperty AngleProperty =
				DependencyProperty.RegisterAttached("Angle",
				typeof(double),
				typeof(PolarPanel),
				new PropertyMetadata(0.0, Property_Changed));

		/// <summary>
		/// Sets the angle.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="radius">The radius.</param>
		public static void SetAngle(UIElement element, double radius)
		{
			element.SetValue(AngleProperty, radius);
		}

		/// <summary>
		/// Gets the angle.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <returns></returns>
		public static double GetAngle(UIElement element)
		{
			return (double)element.GetValue(AngleProperty);
		}
		#endregion

		#region Attached Property - Radius

		public static readonly DependencyProperty RadiusProperty =
				DependencyProperty.RegisterAttached(
				"Radius",
				typeof(double),
				typeof(PolarPanel),
				new PropertyMetadata(0.0, Property_Changed));

		/// <summary>
		/// Sets the radius between the center of the 
		/// child element and the center of the Panel.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="radius">The radius.</param>
		public static void SetRadius(UIElement element, double radius)
		{
			element.SetValue(RadiusProperty, radius);
		}

		/// <summary>
		/// Gets the radius between the center of the 
		/// child element and the center of the Panel.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <returns></returns>
		public static double GetRadius(UIElement element)
		{
			return (double)element.GetValue(RadiusProperty);
		}
		#endregion

		/// <summary>
		/// An Attached Property (angle or radius) 
		/// on a child element
		/// (that invalidates the layout) 
		/// has changed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">
		/// The 
		/// <see cref="System.Windows.DependencyPropertyChangedEventArgs"/>
		/// instance containing the event data.
		/// </param>
		public static void Property_Changed(DependencyObject sender,
			DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement? element = sender as FrameworkElement;

			if (element == null)
			{
				return;
			}

			//We want not the element who was triggered
			//the change (eg: Image) but the parent container
			//panel...in this case the Polar Panel:
			PolarPanel? panel =
				element.Parent as PolarPanel;

			if (panel == null)
			{
				return;
			}

			//Invalidate the layout of the panel
			//due to changes in Angle/Radius of
			//an element:
			panel.InvalidateArrange();
		}


		#region Constructors
		/// <summary>
		/// Initializes a new instance 
		/// of the <see cref="PolarPanel"/> class.
		/// </summary>
		public PolarPanel() { }
		#endregion

		#region MethodOverrides
		/// <summary>
		/// Provides the behavior for the "measure" pass 
		/// of Silverlight layout.
		/// Classes can override this method to define 
		/// their own measure pass behavior.
		/// </summary>
		/// <param name="availableSize">
		/// The available size that this object can give to child objects. 
		/// Infinity can be specified as a value to indicate that the 
		/// object will size to whatever content is available.
		/// </param>
		/// <returns>
		/// The size that this object determines it needs 
		/// during layout, based on its calculations 
		/// of child object allotted sizes.
		/// </returns>
		protected override Size MeasureOverride(Size availableSize)
		{
			//Loop through each child element, 
			//forcing measure to take place:
			foreach (UIElement element in this.Children)
			{
				element.Measure(element.DesiredSize);
			}
			//At this point, they all should be the same 
			//as their stated size -- of the size 
			//this control:
			return availableSize;
		}


		/// <summary>
		/// When implemented in a derived class, 
		/// provides the behavior for 
		/// the "Arrange" pass of Silverlight layout.
		/// </summary>
		/// <param name="finalSize">
		/// The final area within the parent that this 
		/// element should use to arrange itself and its children.
		/// </param>
		/// <returns>The actual size used.</returns>
		protected override Size ArrangeOverride(Size finalSize)
		{

			//Not implemented yet:
			double baseRotationAngle = (double)this.GetValue(AngleProperty);


			foreach (UIElement element in this.Children)
			{
				//Get the Element's Angle and Radius 
				//from the Panel center:
				double elementAngle = (double)element.GetValue(AngleProperty);
				if (_AngleFromTop)
				{
					elementAngle -= 90;//From Right to Top.
				}
				elementAngle += baseRotationAngle;

				double radius = (double)element.GetValue(RadiusProperty);

				//Use helper to Cartesian coordinates
				//from polar coordinates:
				Point point = DegreesToXY(elementAngle, radius);


				//And give it a rectangle in which to draw themselves:
				element.Arrange(
					new Rect(
						point.X, point.Y,
						finalSize.Width, finalSize.Height
						)
						);
			}

			return base.ArrangeOverride(finalSize);
		}
		#endregion

		#region Static Methods
		protected Point DegreesToXY(double degrees, double radius)
		{
			double radians = degrees * Math.PI / 180.0;
			Point result = new Point();
			result.X = Math.Cos(radians) * radius;
			result.Y = Math.Sin(radians) * radius;
			return result;
		}
		#endregion

		/// <summary>
		/// Converts Cartesian coordinates 
		/// to Polar coordinates.
		/// </summary>
		/// <param name="p">The p.</param>
		/// <param name="angle">The angle.</param>
		/// <param name="radius">The radius.</param>
		static void CartesianToPolar(Point p,
			out double angle, out double radius)
		{

			radius = Math.Sqrt((p.X * p.X) + (p.Y + p.Y));
			double div = Math.PI / 2.0;
			if (p.X == 0.0)
			{
				//On X-Axis:
				if (p.Y > 0)
				{
					//To the right:
					angle = div;
					return;
				}
				else if (p.Y < 0)
				{
					//to the left:
					angle = 3 * div;
					return;
				}
			}
			angle = Math.Atan(p.X / p.Y);
		}
	}
}
