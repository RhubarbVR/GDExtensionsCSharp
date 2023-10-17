using System.Text;
using System.Text.Json.Nodes;
using System;

namespace GDShareGenerator
{
	internal class Program
	{
		static Api Api { get; set; }
		static string GenerateFolder { get; set; }

		static string NameSpaceName = "GDSharp";

		static int Main(string[] args) {
			var currentDir = Directory.GetCurrentDirectory();
			var currentDirDepth = currentDir.Where(x => Path.DirectorySeparatorChar == x).Count();
			var gdsharpPath = currentDir;
			for (var i = 0; i < currentDirDepth; i++) {
				gdsharpPath = Path.GetFullPath(Path.Combine(gdsharpPath, ".."));
				if (Directory.Exists(Path.Combine(gdsharpPath, "GDSharp"))) {
					gdsharpPath = Path.Combine(gdsharpPath, "GDSharp");
					break;
				}
			}
			if (!File.Exists(Path.Combine(gdsharpPath, "NativeHeader.cs"))) {
				throw new FileNotFoundException("NativeHeader.cs");
			}
			Console.WriteLine("Found GDSharpPath Path:" + gdsharpPath);
			var generateFolder = Path.Combine(gdsharpPath, "Generated");
			if (!Directory.Exists(generateFolder)) {
				Directory.CreateDirectory(generateFolder);
			}
			else {
				Directory.Delete(generateFolder, true);
				Directory.CreateDirectory(generateFolder);
			}
			GenerateFolder = generateFolder;
			var generateDumpFile = Path.Combine(gdsharpPath, "extension_api.json");
			if (!File.Exists(generateDumpFile)) {
				throw new FileNotFoundException("extension_api.json");
			}
			Api = Api.Create(generateDumpFile);
			{
				//Check if api was loaded well
				var loadTest = Path.Combine(gdsharpPath, "extension_api_load_test.json");
				Api.Save(loadTest, Api);

				var ogFile = File.OpenRead(generateDumpFile);
				var ojObject = JsonObject.Parse(ogFile);
				ogFile.Close();

				var newFile = File.OpenRead(generateDumpFile);
				var newObject = JsonObject.Parse(newFile);
				newFile.Close();

				if (ojObject.ToJsonString() != newObject.ToJsonString()) {
					throw new Exception("Did not load api correctly");
				}
			}			
			Console.WriteLine($"Setting up for Godot Version {Api.header.versionFullName}");

			LoadGlobalEnums();

			return 0;
		}

		static void LoadGlobalEnums() {
			var globalEnumFolder = Path.Combine(GenerateFolder, "GlobalEnums");
			if (!Directory.Exists(globalEnumFolder)) {
				Directory.CreateDirectory(globalEnumFolder);
			}

			for (var i = 0; i < Api.globalEnums.Length; i++) {
				var current = Api.globalEnums[i];

				var enumFile = Path.Combine(globalEnumFolder, ConvertToFileName(Type(current.name) + ".cs"));

				var stringBuilder = new StringBuilder();
				stringBuilder.AppendLine($"namespace {NameSpaceName} {{");
				LoadEnum(stringBuilder, current);
				stringBuilder.AppendLine("}");
				File.WriteAllText(enumFile, stringBuilder.ToString());

			}

		}


		static void LoadEnum(StringBuilder stringBuilder, Api.Enum enumToLoad) {
			Console.WriteLine("Loading Enum :" + enumToLoad.name);
			if (enumToLoad.isBitfield ?? false) {
				stringBuilder.AppendLine("[Flags]");
			}
			stringBuilder.AppendLine($"public enum {Type(enumToLoad.name)} : long {{");
			foreach (var item in enumToLoad.values) {
				stringBuilder.AppendLine($"\t{Type(item.name)} = {item.value},");
			}

			stringBuilder.AppendLine("}");
		}

		public static string ConvertToFileName(string name) {
			return name;
		}


		public static string Type(string name) {
			if(name == name.ToUpper()) {
				name = name.ToLower();
			}

			return SnakeToPascal(name);
		}



		public static string SnakeToPascal(string name) {
			var res = "";
			foreach (var w in name.Split('_')) {
				if (w.Length == 0) {
					res += "_";
				}
				else {
					res += string.Concat(w[0].ToString().ToUpper(), w.AsSpan(1));
				}
			}
			for (var i = 0; i < res.Length - 1; i++) {
				if (char.IsDigit(res[i]) && res[i + 1] == 'd') {
					res = string.Concat(res.AsSpan(0, i + 1), "D", res.AsSpan(i + 2));
				}
			}
			return res;
		}

	}
}