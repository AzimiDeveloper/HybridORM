using System;
using Attribute = System.Attribute;

namespace Hama.Share.Attributes
{


    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class CustomListKeyAttribute : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class CustomListNameAttribute : Attribute
	{
	}










}
