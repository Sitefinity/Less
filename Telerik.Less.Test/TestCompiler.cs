using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Telerik.Less.UnitTests
{
	[TestClass]
	public class TestCompiler
	{
		[TestMethod]
		public void TestCssOutPut()
		{
			string lessFile = Environment.CurrentDirectory + @"\test.less";
			string output = "body{background-color:Green}\n";

			LessCompiler compiler = null;
			try
			{
				compiler = new LessCompiler();
			}
			catch (Exception)
			{
				Assert.Fail("Compiler was not created successfully!");
			}

			string css = string.Empty;
			if (compiler != null)
			{
				css = compiler.CompileFile(lessFile, true);
			}

			Assert.AreEqual(output, css);
		}

        [TestMethod]
        public void TestLessOperations()
        {
            string lessFile = Environment.CurrentDirectory + @"\test2.less";
            string output = "#header{color:#333;border-left:1px;border-right:2px}\n#footer{color:#333}\n";

            LessCompiler compiler = null;
            try
            {
                compiler = new LessCompiler();
            }
            catch (Exception)
            {
                Assert.Fail("Compiler was not created successfully!");
            }

            string css = string.Empty;
            if (compiler != null)
            {
                css = compiler.CompileFile(lessFile, true);
            }

            Assert.AreEqual(output, css);
        }
	}
}
