using System;
using System.Text;
using System.Runtime.InteropServices;

public class Tests {

	public static int delegate_test (int a)
	{
		if (a == 2)
			return 0;

		return 1;
	}
	
	[StructLayout (LayoutKind.Sequential)]
	public struct SimpleStruct {
		public bool a;
		public bool b;
		public bool c;
		public string d;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string d2;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct SimpleStruct2 {
		public bool a;
		public bool b;
		public bool c;
		public string d;
		public byte e;
		public double f;
		public byte g;
		public long h;
	}

	[StructLayout (LayoutKind.Sequential, Size=0)]
	public struct EmptyStruct {
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct DelegateStruct {
		public int a;
		public SimpleDelegate del;
		[MarshalAs(UnmanagedType.FunctionPtr)] 
		public SimpleDelegate del2;
	}

	/* sparcv9 has complex conventions when passing structs with doubles in them 
	   by value, some simple tests for them */
	[StructLayout (LayoutKind.Sequential)]
	public struct Point {
		public double x;
		public double y;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct MixedPoint {
		public int x;
		public double y;
	}

	[StructLayout (LayoutKind.Sequential)]
	public class SimpleClass {
		public bool a;
		public bool b;
		public bool c;
		public string d;
		public byte e;
		public double f;
		public byte g;
		public long h;
	}

	[StructLayout (LayoutKind.Sequential)]
	public class EmptyClass {
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct LongAlignStruct {
		public int a;
		public long b;
		public long c;
	}

	[StructLayout(LayoutKind.Sequential)]
	public class VectorList
	{
		public int a = 1;
		public int b = 2;
	}

	[StructLayout (LayoutKind.Sequential)]
	class SimpleObj
	{
		public string str;
		public int i;
	}

	[DllImport ("libnot-found", EntryPoint="not_found")]
	public static extern int mono_library_not_found ();

	[DllImport ("libtest", EntryPoint="not_found")]
	public static extern int mono_entry_point_not_found ();

	[DllImport ("libtest.dll", EntryPoint="mono_test_marshal_char")]
	public static extern int mono_test_marshal_char_2 (char a1);

	[DllImport ("test", EntryPoint="mono_test_marshal_char")]
	public static extern int mono_test_marshal_char_3 (char a1);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_char")]
	public static extern int mono_test_marshal_char (char a1);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_char_array", CharSet=CharSet.Unicode)]
	public static extern int mono_test_marshal_char_array (char[] a1);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_bool_byref")]
	public static extern int mono_test_marshal_bool_byref (int a, ref bool b, int c);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_array")]
	public static extern int mono_test_marshal_array (int [] a1);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_empty_string_array")]
	public static extern int mono_test_marshal_empty_string_array (string [] a1);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_string_array")]
	public static extern int mono_test_marshal_string_array (string [] a1);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_unicode_string_array", CharSet=CharSet.Unicode)]
	public static extern int mono_test_marshal_unicode_string_array (string [] a1, [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)]string [] a2);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_stringbuilder_array")]
	public static extern int mono_test_marshal_stringbuilder_array (StringBuilder [] a1);	

	[DllImport ("libtest", EntryPoint="mono_test_marshal_inout_array")]
	public static extern int mono_test_marshal_inout_array ([In, Out] int [] a1);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_out_array")]
	public static extern int mono_test_marshal_out_array ([Out] int [] a1);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_inout_nonblittable_array", CharSet = CharSet.Unicode)]
	public static extern int mono_test_marshal_inout_nonblittable_array ([In, Out] char [] a1);
	
	[DllImport ("libtest", EntryPoint="mono_test_marshal_struct")]
	public static extern int mono_test_marshal_struct (SimpleStruct ss);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_struct2")]
	public static extern int mono_test_marshal_struct2 (SimpleStruct2 ss);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_struct2_2")]
	public static extern int mono_test_marshal_struct2_2 (int i, int j, int k, SimpleStruct2 ss);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_point")]
	public static extern int mono_test_marshal_point (Point p);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_mixed_point")]
	public static extern int mono_test_marshal_mixed_point (MixedPoint p);

	[DllImport ("libtest", EntryPoint="mono_test_empty_struct")]
	public static extern int mono_test_empty_struct (int a, EmptyStruct es, int b);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_struct_array")]
	public static extern int mono_test_marshal_struct_array (SimpleStruct2[] ss);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_long_align_struct_array")]
	public static extern int mono_test_marshal_long_align_struct_array (LongAlignStruct[] ss);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_class")]
	public static extern SimpleClass mono_test_marshal_class (int i, int j, int k, SimpleClass ss, int l);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_byref_class")]
	public static extern int mono_test_marshal_byref_class (ref SimpleClass ss);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_delegate")]
	public static extern int mono_test_marshal_delegate (SimpleDelegate d);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_delegate_struct")]
	public static extern DelegateStruct mono_test_marshal_delegate_struct (DelegateStruct d);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_return_delegate")]
	public static extern SimpleDelegate mono_test_marshal_return_delegate (SimpleDelegate d);

	[DllImport ("libtest", EntryPoint="mono_test_return_vtype")]
	public static extern SimpleStruct mono_test_return_vtype (IntPtr i);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_stringbuilder")]
	public static extern void mono_test_marshal_stringbuilder (StringBuilder sb, int len);

	[DllImport ("libtest", EntryPoint="mono_test_marshal_stringbuilder_unicode", CharSet=CharSet.Unicode)]
	public static extern void mono_test_marshal_stringbuilder_unicode (StringBuilder sb, int len);

	[DllImport ("libtest", EntryPoint="mono_test_last_error", SetLastError=true)]
	public static extern void mono_test_last_error (int err);

	[DllImport ("libtest", EntryPoint="mono_test_asany")]
	public static extern int mono_test_asany ([MarshalAs (UnmanagedType.AsAny)] object o, int what);

	[DllImport ("libtest", EntryPoint="mono_test_asany", CharSet=CharSet.Unicode)]
	public static extern int mono_test_asany_unicode ([MarshalAs (UnmanagedType.AsAny)] object o, int what);

	[DllImport ("libtest")]
        static extern int class_marshal_test0 (SimpleObj obj);

	[DllImport ("libtest")]
        static extern void class_marshal_test1 (out SimpleObj obj);

	[DllImport ("libtest")]
        static extern int class_marshal_test4 (SimpleObj obj);
	
	[DllImport ("libtest")]
        static extern int string_marshal_test0 (string str);

	[DllImport ("libtest")]
        static extern void string_marshal_test1 (out string str);

	[DllImport ("libtest")]
        static extern int string_marshal_test2 (ref string str);

	[DllImport ("libtest")]
        static extern int string_marshal_test3 (string str);

	public delegate int SimpleDelegate (int a);

	public static int Main (string[] args) {
		return TestDriver.RunTests (typeof (Tests), args);
	}

	public static int test_0_marshal_char () {
		return mono_test_marshal_char ('a');
	}

	public static int test_0_marshal_char_array () {
		// a unicode char[] is implicitly marshalled as [Out]
		char[] buf = new char [32];
		mono_test_marshal_char_array (buf);
		string s = new string (buf);
		if (s.StartsWith ("abcdef"))
			return 0;
		else
			return 1;
	}

	public static int test_1225_marshal_array () {
		int [] a1 = new int [50];
		for (int i = 0; i < 50; i++)
			a1 [i] = i;

		return mono_test_marshal_array (a1);
	}

	public static int test_1225_marshal_inout_array () {
		int [] a1 = new int [50];
		for (int i = 0; i < 50; i++)
			a1 [i] = i;

		int res = mono_test_marshal_inout_array (a1);

		for (int i = 0; i < 50; i++)
			if (a1 [i] != 50 - i) {
				Console.WriteLine ("X: " + i + " " + a1 [i]);
				return 2;
			}

		return res;
	}

	public static int test_0_marshal_inout_array () {
		int [] a1 = new int [50];

		int res = mono_test_marshal_out_array (a1);

		for (int i = 0; i < 50; i++)
			if (a1 [i] != i) {
				Console.WriteLine ("X: " + i + " " + a1 [i]);
				return 2;
			}

		return 0;
	}

	public static int test_0_marshal_inout_nonblittable_array () {
		char [] a1 = new char [10];
		for (int i = 0; i < 10; i++)
			a1 [i] = "Hello, World" [i];

		int res = mono_test_marshal_inout_nonblittable_array (a1);

		for (int i = 0; i < 10; i++)
			if (a1 [i] != 'F')
				return 2;

		return res;
	}

	public static int test_0_marshal_struct () {
		SimpleStruct ss = new  SimpleStruct ();
		ss.b = true;
		ss.d = "TEST";
		
		return mono_test_marshal_struct (ss);
	}

	public static int test_0_marshal_struct2 () {
		SimpleStruct2 ss2 = new  SimpleStruct2 ();
		ss2.b = true;
		ss2.d = "TEST";
		ss2.e = 99;
		ss2.f = 1.5;
		ss2.g = 42;
		ss2.h = 123L;

		return mono_test_marshal_struct2 (ss2);
	}

	public static int test_0_marshal_struct3 () {
		SimpleStruct2 ss2 = new  SimpleStruct2 ();
		ss2.b = true;
		ss2.d = "TEST";
		ss2.e = 99;
		ss2.f = 1.5;
		ss2.g = 42;
		ss2.h = 123L;

		return mono_test_marshal_struct2_2 (10, 11, 12, ss2);
	}

	public static int test_0_marshal_empty_struct () {
		EmptyStruct es = new EmptyStruct ();

		if (mono_test_empty_struct (1, es, 2) != 0)
			return 1;
		
		return 0;
	}

	public static int test_0_marshal_struct_array () {
		SimpleStruct2[] ss_arr = new SimpleStruct2 [2];

		SimpleStruct2 ss2 = new SimpleStruct2 ();
		ss2.b = true;
		ss2.d = "TEST";
		ss2.e = 99;
		ss2.f = 1.5;
		ss2.g = 42;
		ss2.h = 123L;

		ss_arr [0] = ss2;

		ss2.b = false;
		ss2.d = "TEST2";
		ss2.e = 100;
		ss2.f = 2.5;
		ss2.g = 43;
		ss2.h = 124L;

		ss_arr [1] = ss2;

		return mono_test_marshal_struct_array (ss_arr);
	}

	public static int test_105_marshal_long_align_struct_array () {
		LongAlignStruct[] ss_arr = new LongAlignStruct [2];

		LongAlignStruct ss = new LongAlignStruct ();
		ss.a = 5;
		ss.b = 10;
		ss.c = 15;

		ss_arr [0] = ss;

		ss.a = 20;
		ss.b = 25;
		ss.c = 30;

		ss_arr [1] = ss;

		return mono_test_marshal_long_align_struct_array (ss_arr);
	}

	/* Test classes as arguments and return values */
	public static int test_0_marshal_class () {
		SimpleClass ss = new  SimpleClass ();
		ss.b = true;
		ss.d = "TEST";
		ss.e = 99;
		ss.f = 1.5;
		ss.g = 42;
		ss.h = 123L;

		SimpleClass res = mono_test_marshal_class (10, 11, 12, ss, 14);
		if (res == null)
			return 1;
		if  (! (res.a == ss.a && res.b == ss.b && res.c == ss.c && 
				res.d == ss.d && res.e == ss.e && res.f == ss.f &&
				res.g == ss.g && res.h == ss.h))
			return 2;

		/* Test null arguments and results */
		res = mono_test_marshal_class (10, 11, 12, null, 14);
		if (res != null)
			return 3;

		return 0;
	}

	public static int test_0_marshal_byref_class () {
		SimpleClass ss = new  SimpleClass ();
		ss.b = true;
		ss.d = "TEST";
		ss.e = 99;
		ss.f = 1.5;
		ss.g = 42;
		ss.h = 123L;

		int res = mono_test_marshal_byref_class (ref ss);
		if (ss.d != "TEST-RES")
			return 1;

		return 0;
	}

	public static int test_0_marshal_delegate () {
		SimpleDelegate d = new SimpleDelegate (delegate_test);

		return mono_test_marshal_delegate (d);
	}

	public static int test_0_marshal_return_delegate () {
		SimpleDelegate d = new SimpleDelegate (delegate_test);

		SimpleDelegate d2 = mono_test_marshal_return_delegate (d);

		return d2 (2);
	}

	public static int test_0_marshal_delegate_struct () {
		DelegateStruct s = new DelegateStruct ();

		s.a = 2;
		s.del = new SimpleDelegate (delegate_test);
		s.del2 = new SimpleDelegate (delegate_test);

		DelegateStruct res = mono_test_marshal_delegate_struct (s);

		if (res.a != 0)
			return 1;
		if (res.del (2) != 0)
			return 2;
		if (res.del2 (2) != 0)
			return 3;

		return 0;
	}

	public static int test_0_marshal_point () {
		Point pt = new Point();
		pt.x = 1.25;
		pt.y = 3.5;
		
		return mono_test_marshal_point(pt);
	}

	public static int test_0_marshal_mixed_point () {
		MixedPoint mpt = new MixedPoint();
		mpt.x = 5;
		mpt.y = 6.75;
		
		return mono_test_marshal_mixed_point(mpt);
	}

	public static int test_0_marshal_bool_byref () {
		bool b = true;
		if (mono_test_marshal_bool_byref (99, ref b, 100) != 1)
			return 1;
		b = false;
		if (mono_test_marshal_bool_byref (99, ref b, 100) != 0)
			return 12;
		if (b != true)
			return 13;

		return 0;
	}

	public static int test_0_return_vtype () {
		SimpleStruct ss = mono_test_return_vtype (new IntPtr (5));

		if (!ss.a && ss.b && !ss.c && ss.d == "TEST" && ss.d2 == "TEST2")
			return 0;

		return 1;
	}

	public static int test_0_marshal_stringbuilder () {
		StringBuilder sb = new StringBuilder(255);
		sb.Append ("ABCD");
		mono_test_marshal_stringbuilder (sb, sb.Capacity);
		String res = sb.ToString();

		if (res != "This is my message.  Isn't it nice?")
			return 1;  
		
		return 0;
	}

	public static int test_0_marshal_stringbuilder_unicode () {
		StringBuilder sb = new StringBuilder(255);
		mono_test_marshal_stringbuilder_unicode (sb, sb.Capacity);
		String res = sb.ToString();

		if (res != "This is my message.  Isn't it nice?")
			return 1;  
		
		return 0;
	}

	public static int test_0_marshal_empty_string_array () {
		return mono_test_marshal_empty_string_array (null);
	}

	public static int test_0_marshal_string_array () {
		return mono_test_marshal_string_array (new String [] { "ABC", "DEF" });
	}

	public static int test_0_marshal_unicode_string_array () {
		return mono_test_marshal_unicode_string_array (new String [] { "ABC", "DEF" }, new String [] { "ABC", "DEF" });
	}

	public static int test_0_marshal_stringbuilder_array () {
		StringBuilder sb1 = new StringBuilder ("ABC");
		StringBuilder sb2 = new StringBuilder ("DEF");

		int res = mono_test_marshal_stringbuilder_array (new StringBuilder [] { sb1, sb2 });
		if (res != 0)
			return res;
		if (sb1.ToString () != "DEF")
			return 5;
		if (sb2.ToString () != "ABC")
			return 6;
		return 0;
	}

	public static int test_0_last_error () {
		mono_test_last_error (5);
		if (Marshal.GetLastWin32Error () == 5)
			return 0;
		else
			return 1;
	}

	public static int test_0_library_not_found () {

		try {
			mono_entry_point_not_found ();
			return 1;
		}
		catch (EntryPointNotFoundException) {
		}

		return 0;
	}

	public static int test_0_entry_point_not_found () {

		try {
			mono_library_not_found ();
			return 1;
		}
		catch (DllNotFoundException) {
		}

		return 0;
	}

	/* Check that the runtime trims .dll from the library name */
	public static int test_0_trim_dll_from_name () {

		mono_test_marshal_char_2 ('A');

		return 0;
	}

	/* Check that the runtime adds lib to to the library name */
	public static int test_0_add_lib_to_name () {

		mono_test_marshal_char_3 ('A');

		return 0;
	}

	class C {
		public int i;
	}

	public static int test_0_asany () {
		if (mono_test_asany (5, 1) != 0)
			return 1;

		if (mono_test_asany ("ABC", 2) != 0)
			return 2;

		SimpleStruct2 ss2 = new  SimpleStruct2 ();
		ss2.b = true;
		ss2.d = "TEST";
		ss2.e = 99;
		ss2.f = 1.5;
		ss2.g = 42;
		ss2.h = 123L;

		if (mono_test_asany (ss2, 3) != 0)
			return 3;

		if (mono_test_asany_unicode ("ABC", 4) != 0)
			return 4;

		try {
			C c = new C ();
			c.i = 5;
			mono_test_asany (c, 0);
			return 5;
		}
		catch (ArgumentException) {
		}

		try {
			mono_test_asany (new Object (), 0);
			return 6;
		}
		catch (ArgumentException) {
		}

		return 0;
	}

	/* Byref String Array */

	[DllImport ("libtest", EntryPoint="mono_test_marshal_byref_string_array")]
	public static extern int mono_test_marshal_byref_string_array (ref string[] data);

	public static int test_0_byref_string_array () {

		string[] arr = null;

		if (mono_test_marshal_byref_string_array (ref arr) != 0)
			return 1;

		arr = new string[] { "Alpha", "Beta", "Gamma" };

		if (mono_test_marshal_byref_string_array (ref arr) != 1)
			return 2;

		/* FIXME: Test returned array and out case */

		return 0;
	}

	/*
	 * AMD64 small structs-by-value tests.
	 */

	/* TEST 1: 16 byte long INTEGER struct */

	[StructLayout(LayoutKind.Sequential)]
	public struct Amd64Struct1 {
		public int i;
		public int j;
		public int k;
		public int l;
	}
	
	[DllImport ("libtest", EntryPoint="mono_test_marshal_amd64_pass_return_struct1")]
	public static extern Amd64Struct1 mono_test_marshal_amd64_pass_return_struct1 (Amd64Struct1 s);

	public static int test_0_amd64_struct1 () {
		Amd64Struct1 s = new Amd64Struct1 ();
		s.i = 5;
		s.j = -5;
		s.k = 0xffffff;
		s.l = 0xfffffff;

		Amd64Struct1 s2 = mono_test_marshal_amd64_pass_return_struct1 (s);

		return ((s2.i == 6) && (s2.j == -4) && (s2.k == 0x1000000) && (s2.l == 0x10000000)) ? 0 : 1;
	}

	/* TEST 2: 8 byte long INTEGER struct */

	[StructLayout(LayoutKind.Sequential)]
	public struct Amd64Struct2 {
		public int i;
		public int j;
	}
	
	[DllImport ("libtest", EntryPoint="mono_test_marshal_amd64_pass_return_struct2")]
	public static extern Amd64Struct2 mono_test_marshal_amd64_pass_return_struct2 (Amd64Struct2 s);

	public static int test_0_amd64_struct2 () {
		Amd64Struct2 s = new Amd64Struct2 ();
		s.i = 5;
		s.j = -5;

		Amd64Struct2 s2 = mono_test_marshal_amd64_pass_return_struct2 (s);

		return ((s2.i == 6) && (s2.j == -4)) ? 0 : 1;
	}

	/* TEST 3: 4 byte long INTEGER struct */

	[StructLayout(LayoutKind.Sequential)]
	public struct Amd64Struct3 {
		public int i;
	}
	
	[DllImport ("libtest", EntryPoint="mono_test_marshal_amd64_pass_return_struct3")]
	public static extern Amd64Struct3 mono_test_marshal_amd64_pass_return_struct3 (Amd64Struct3 s);

	public static int test_0_amd64_struct3 () {
		Amd64Struct3 s = new Amd64Struct3 ();
		s.i = -5;

		Amd64Struct3 s2 = mono_test_marshal_amd64_pass_return_struct3 (s);

		return (s2.i == -4) ? 0 : 1;
	}

	/* Test 4: 16 byte long FLOAT struct */

	[StructLayout(LayoutKind.Sequential)]
	public struct Amd64Struct4 {
		public double d1, d2;
	}
	
	[DllImport ("libtest", EntryPoint="mono_test_marshal_amd64_pass_return_struct4")]
	public static extern Amd64Struct4 mono_test_marshal_amd64_pass_return_struct4 (Amd64Struct4 s);

	public static int test_0_amd64_struct4 () {
		Amd64Struct4 s = new Amd64Struct4 ();
		s.d1 = 5.0;
		s.d2 = -5.0;

		Amd64Struct4 s2 = mono_test_marshal_amd64_pass_return_struct4 (s);

		return (s2.d1 == 6.0 && s2.d2 == -4.0) ? 0 : 1;
	}

	/*
	 * IA64 struct tests
	 */

	/* Test 5: Float HFA */

	[StructLayout(LayoutKind.Sequential)]
	public struct TestStruct5 {
		public float d1, d2;
	}
	
	[DllImport ("libtest", EntryPoint="mono_test_marshal_ia64_pass_return_struct5")]
	public static extern TestStruct5 mono_test_marshal_ia64_pass_return_struct5 (double d1, double d2, TestStruct5 s, double f3, double f4);

	public static int test_0_ia64_struct5 () {
		TestStruct5 s = new TestStruct5 ();
		s.d1 = 5.0f;
		s.d2 = -5.0f;

		TestStruct5 s2 = mono_test_marshal_ia64_pass_return_struct5 (1.0, 2.0, s, 3.0, 4.0);

		return (s2.d1 == 8.0 && s2.d2 == 2.0) ? 0 : 1;
	}

	/* Test 6: Double HFA */

	[StructLayout(LayoutKind.Sequential)]
	public struct TestStruct6 {
		public double d1, d2;
	}
	
	[DllImport ("libtest", EntryPoint="mono_test_marshal_ia64_pass_return_struct6")]
	public static extern TestStruct6 mono_test_marshal_ia64_pass_return_struct6 (double d1, double d2, TestStruct6 s, double f3, double f4);

	public static int test_0_ia64_struct6 () {
		TestStruct6 s = new TestStruct6 ();
		s.d1 = 6.0;
		s.d2 = -6.0;

		TestStruct6 s2 = mono_test_marshal_ia64_pass_return_struct6 (1.0, 2.0, s, 3.0, 4.0);

		return (s2.d1 == 9.0 && s2.d2 == 1.0) ? 0 : 1;
	}
	
	/* Blittable class */
	[DllImport("libtest")]
	private static extern VectorList TestVectorList (VectorList vl);

	public static int test_0_marshal_blittable_class () {
		VectorList v1 = new VectorList ();

		/* Since it is blittable, it looks like it is passed as in/out */
		VectorList v2 = TestVectorList (v1);

		if (v1.a != 2 || v1.b != 3)
			return 1;
		
		if (v2.a != 2 || v2.b != 3)
			return 2;
		
		return 0;
	}

	public static int test_0_marshal_byval_class () {
		SimpleObj obj0 = new SimpleObj ();
		obj0.str = "T1";
		obj0.i = 4;
		
		if (class_marshal_test0 (obj0) != 0)
			return 1;

		return 0;
	}

	public static int test_0_marshal_byval_class_null () {
		if (class_marshal_test4 (null) != 0)
			return 1;

		return 0;
	}

	public static int test_0_marshal_out_class () {
		SimpleObj obj1;

		class_marshal_test1 (out obj1);

		if (obj1.str != "ABC")
			return 1;

		if (obj1.i != 5)
			return 2;

		return 0;
	}

	public static int test_0_marshal_string () {
		return string_marshal_test0 ("TEST0");
	}

	public static int test_0_marshal_out_string () {
		string res;
		
		string_marshal_test1 (out res);

		if (res != "TEST1")
			return 1;

		return 0;
	}

	public static int test_0_marshal_byref_string () {
		string res = "TEST1";

		return string_marshal_test2 (ref res);
	}

	public static int test_0_marshal_null_string () {
		return string_marshal_test3 (null);
	}

	[DllImport ("libtest", EntryPoint="mono_test_stdcall_name_mangling", CallingConvention=CallingConvention.StdCall)]
	public static extern int mono_test_stdcall_name_mangling (int a, int b, int c);

	public static int test_0_stdcall_name_mangling () {
		return mono_test_stdcall_name_mangling (0, 1, 2) == 3 ? 0 : 1;
	}

	/*
	 * Pointers to structures can not be passed
	 */

	public struct CharInfo {
		public char Character;
		public short Attributes;
	}

	[DllImport ("libtest", EntryPoint="mono_test_marshal_struct")]
	public static unsafe extern int mono_test_marshal_ptr_to_struct (CharInfo *ptr);

	public static unsafe int test_0_marshal_ptr_to_struct () {
		CharInfo [] buffer = new CharInfo [1];
		fixed (CharInfo *ptr = &buffer [0]) {
			try {
				mono_test_marshal_ptr_to_struct (ptr);
				return 1;
			}
			catch (MarshalDirectiveException) {
				return 0;
			}
		}
		return 1;
	}

	/*
	 * LPWStr marshalling
	 */

	[DllImport("libtest", EntryPoint="test_lpwstr_marshal")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	private static extern string mono_test_marshal_lpwstr_marshal(
		[MarshalAs(UnmanagedType.LPWStr)] string s,
		int length );

	[DllImport("libtest", EntryPoint="test_lpwstr_marshal", CharSet=CharSet.Unicode)]
	private static extern string mono_test_marshal_lpwstr_marshal2(
		string s,
		int length );

	public static int test_0_pass_return_lwpstr () {
		string s = "ABC";
		
		string res = mono_test_marshal_lpwstr_marshal (s, s.Length);

		if (res != "ABC")
			return 1;

		string res2 = mono_test_marshal_lpwstr_marshal2 (s, s.Length);

		if (res2 != "ABC")
			return 2;
		
		return 0;		
	}

	/*
	 * Byref bool marshalling
	 */

	[DllImport("libtest")]
	extern static int marshal_test_ref_bool
	(
		int i, 
		[MarshalAs(UnmanagedType.I1)] ref bool b1, 
		[MarshalAs(UnmanagedType.VariantBool)] ref bool b2, 
		ref bool b3
	);

	public static int test_0_pass_byref_bool () {
		for (int i = 0; i < 8; i++)
		{
			bool b1 = (i & 4) != 0;
			bool b2 = (i & 2) != 0;
			bool b3 = (i & 1) != 0;
			bool orig_b1 = b1, orig_b2 = b2, orig_b3 = b3;
			if (marshal_test_ref_bool(i, ref b1, ref b2, ref b3) != 0)
				return 4 * i + 1;
			if (b1 != !orig_b1)
				return 4 * i + 2;
			if (b2 != !orig_b2)
				return 4 * i + 3;
			if (b3 != !orig_b3)
				return 4 * i + 4;
		}

		return 0;
	}

	/*
	 * Bool struct field marshalling
	 */

	struct BoolStruct
	{
		public int i;
		[MarshalAs(UnmanagedType.I1)] public bool b1;
		[MarshalAs(UnmanagedType.VariantBool)] public bool b2;
		public bool b3;
	}

	[DllImport("libtest")]
	extern static int marshal_test_bool_struct(ref BoolStruct s);

	public static int test_0_pass_bool_in_struct () {
		for (int i = 0; i < 8; i++)
		{
			BoolStruct s = new BoolStruct();
			s.i = i;
			s.b1 = (i & 4) != 0;
			s.b2 = (i & 2) != 0;
			s.b3 = (i & 1) != 0;
			BoolStruct orig = s;
			if (marshal_test_bool_struct(ref s) != 0)
				return 4 * i + 33;
			if (s.b1 != !orig.b1)
				return 4 * i + 34;
			if (s.b2 != !orig.b2)
				return 4 * i + 35;
			if (s.b3 != !orig.b3)
				return 4 * i + 36;
		}

		return 0;
	}

}

