﻿using UtinyRipper.Classes;
using UtinyRipper.Classes.Textures;
using UtinyRipper.Exporter.YAML;

namespace UtinyRipper.AssetExporters.Classes
{
	public readonly struct TextureImportSettings : IYAMLExportable
	{
		public TextureImportSettings(TextureSettings settings)
		{
			m_textureSettings = settings;
		}
		
		public YAMLNode ExportYAML(IAssetsExporter exporter)
		{
			int version = TextureSettings.GetSerializedVersion(exporter.Version);
			YAMLMappingNode node = new YAMLMappingNode();
			node.AddSerializedVersion(version);
			node.Add("filterMode", (int)m_textureSettings.FilterMode);
			node.Add("aniso", m_textureSettings.Aniso);
			node.Add("mipBias", m_textureSettings.MipBias);
			if (version >= 2)
			{
				node.Add("wrapU", (int)m_textureSettings.WrapU);
				node.Add("wrapV", (int)m_textureSettings.WrapV);
				node.Add("wrapW", (int)m_textureSettings.WrapW);
			}
			else
			{
				node.Add("wrapMode", (int)m_textureSettings.WrapU);
			}
			return node;
		}

		private readonly TextureSettings m_textureSettings;
	}
}
