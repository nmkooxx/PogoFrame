﻿namespace pogorock
{
	using UnityEngine;
	using System.Collections;
	using System;
	using System.IO;

	public class DAM_FilesCopy
	{
		public static void copyDirectory (string sourceDirectory, string destDirectory)
		{
			//判断源目录和目标目录是否存在，如果不存在，则创建一个目录
			if (!Directory.Exists (sourceDirectory)) {
				Directory.CreateDirectory (sourceDirectory);
			}
			if (!Directory.Exists (destDirectory)) {
				Directory.CreateDirectory (destDirectory);
			}
			//拷贝文件
			copyFile (sourceDirectory, destDirectory);

			//拷贝子目录       
			//获取所有子目录名称
			string[] directionName = Directory.GetDirectories (sourceDirectory);

			foreach (string directionPath in directionName) {
				//根据每个子目录名称生成对应的目标子目录名称
				string directionPathTemp = destDirectory + "/" + directionPath.Substring (sourceDirectory.Length + 1);

				//递归下去
				copyDirectory (directionPath, directionPathTemp);
			}                     
		}

		public static void copyFile (string sourceDirectory, string destDirectory)
		{
			//获取所有文件名称
			if (Directory.Exists (sourceDirectory)) {

				string[] fileName = Directory.GetFiles (sourceDirectory);

				foreach (string filePath in fileName) {
					if (filePath.EndsWith (".DS_Store")) {
						continue;
					}

					//根据每个文件名称生成对应的目标文件名称
					string filePathTemp = destDirectory + "/" + filePath.Substring (sourceDirectory.Length + 1);

					//若不存在，直接复制文件；若存在，覆盖复制
					if (File.Exists (filePathTemp)) {
						File.Copy (filePath, filePathTemp, true);
					} else {
						File.Copy (filePath, filePathTemp);
					}
				}
			} else if (File.Exists (sourceDirectory)) {
				//根据每个文件名称生成对应的目标文件名称

				//若不存在，直接复制文件；若存在，覆盖复制
				if (File.Exists (destDirectory)) {
					File.Copy (sourceDirectory, destDirectory, true);
				} else {
					string fileDirectory = Path.GetDirectoryName (destDirectory);
					if (Directory.Exists (fileDirectory) == false) {
						Directory.CreateDirectory (fileDirectory);
					}
					File.Copy (sourceDirectory, destDirectory);
				}
			}
		}

		public static void cleanDirectory (string sourceDirectory)
		{
			//判断源目录和目标目录是否存在，如果不存在，则创建一个目录
			if (!Directory.Exists (sourceDirectory)) {
				return;
			}
			//拷贝文件
			cleanFile (sourceDirectory);

			//拷贝子目录       
			//获取所有子目录名称
			string[] directionName = Directory.GetDirectories (sourceDirectory);

			foreach (string directionPath in directionName) {
				//递归下去
				cleanDirectory (directionPath);
			}                     
		}

		public static void cleanFile (string sourceDirectory)
		{
			//获取所有文件名称
			string[] fileName = Directory.GetFiles (sourceDirectory);

			foreach (string filePath in fileName) {
				if (filePath.EndsWith (".DS_Store") || filePath.EndsWith (".meta")) {
					File.Delete (filePath);	
				}
			}
		}
	}
}