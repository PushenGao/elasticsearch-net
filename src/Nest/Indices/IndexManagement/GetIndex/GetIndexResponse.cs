﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	public interface IGetIndexResponse : IResponse
	{
		IDictionary<string, IndexState> Indices { get; set; }
	}

	[JsonObject]
	public class GetIndexResponse : BaseResponse, IGetIndexResponse
	{
		public GetIndexResponse()
		{
			this.Indices = new Dictionary<string, IndexState>();
		}
		public IDictionary<string, IndexState> Indices { get; set; }
	}

	public class IndexMetadata
	{
		public IDictionary<string, object> Settings { get; set; }
		
		/// <summary>
		/// Dynamic view of the settings object, useful for reading value from the settings
		/// as it allows you to chain without nullrefs. Cannot be used to assign setting values though
		/// </summary>
		public dynamic AsExpando { get; internal set; }
		
		public AnalysisSettings Analysis { get; set; }

		public IDictionary<string, TypeMapping> Mappings { get; set; }

		[JsonConverter(typeof(DictionaryKeysAreNotFieldNamesJsonConverter))]
		public Dictionary<string, CreateAliasOperation> Aliases { get; set; }
			
		[JsonConverter(typeof(DictionaryKeysAreNotFieldNamesJsonConverter))]
		public IWarmers Warmers { get; set; }

		public SimilaritySettings Similarity { get; internal set; }
	}
}
