﻿
namespace NomadCode.BotFramework
{
	using Microsoft.Rest;
	using Microsoft.Rest.Serialization;
	using Newtonsoft.Json;
	using System.Collections;
	using System.Collections.Generic;
	using System.Net;
	using System.Net.Http;

	/// <summary>
	/// Direct Line 3.0
	/// </summary>
	public partial class DirectLineClient : ServiceClient<DirectLineClient>, IDirectLineClient
	{
		/// <summary>
		/// The base URI of the service.
		/// </summary>
		public System.Uri BaseUri { get; set; }

		/// <summary>
		/// Gets or sets json serialization settings.
		/// </summary>
		public JsonSerializerSettings SerializationSettings { get; private set; }

		/// <summary>
		/// Gets or sets json deserialization settings.
		/// </summary>
		public JsonSerializerSettings DeserializationSettings { get; private set; }

		/// <summary>
		/// Subscription credentials which uniquely identify client subscription.
		/// </summary>
		public ServiceClientCredentials Credentials { get; private set; }

		/// <summary>
		/// Gets the IConversations.
		/// </summary>
		public virtual IConversations Conversations { get; private set; }

		/// <summary>
		/// Gets the ITokens.
		/// </summary>
		public virtual ITokens Tokens { get; private set; }

		/// <summary>
		/// Initializes a new instance of the DirectLineClient class.
		/// </summary>
		/// <param name='handlers'>
		/// Optional. The delegating handlers to add to the http client pipeline.
		/// </param>
		protected DirectLineClient (params DelegatingHandler [] handlers) : base (handlers)
		{
			Initialize ();
		}

		/// <summary>
		/// Initializes a new instance of the DirectLineClient class.
		/// </summary>
		/// <param name='rootHandler'>
		/// Optional. The http client handler used to handle http transport.
		/// </param>
		/// <param name='handlers'>
		/// Optional. The delegating handlers to add to the http client pipeline.
		/// </param>
		protected DirectLineClient (HttpClientHandler rootHandler, params DelegatingHandler [] handlers) : base (rootHandler, handlers)
		{
			Initialize ();
		}

		/// <summary>
		/// Initializes a new instance of the DirectLineClient class.
		/// </summary>
		/// <param name='baseUri'>
		/// Optional. The base URI of the service.
		/// </param>
		/// <param name='handlers'>
		/// Optional. The delegating handlers to add to the http client pipeline.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// Thrown when a required parameter is null
		/// </exception>
		protected DirectLineClient (System.Uri baseUri, params DelegatingHandler [] handlers) : this (handlers)
		{
			if (baseUri == null)
			{
				throw new System.ArgumentNullException ("baseUri");
			}
			BaseUri = baseUri;
		}

		/// <summary>
		/// Initializes a new instance of the DirectLineClient class.
		/// </summary>
		/// <param name='baseUri'>
		/// Optional. The base URI of the service.
		/// </param>
		/// <param name='rootHandler'>
		/// Optional. The http client handler used to handle http transport.
		/// </param>
		/// <param name='handlers'>
		/// Optional. The delegating handlers to add to the http client pipeline.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// Thrown when a required parameter is null
		/// </exception>
		protected DirectLineClient (System.Uri baseUri, HttpClientHandler rootHandler, params DelegatingHandler [] handlers) : this (rootHandler, handlers)
		{
			if (baseUri == null)
			{
				throw new System.ArgumentNullException ("baseUri");
			}
			BaseUri = baseUri;
		}

		/// <summary>
		/// Initializes a new instance of the DirectLineClient class.
		/// </summary>
		/// <param name='credentials'>
		/// Required. Subscription credentials which uniquely identify client subscription.
		/// </param>
		/// <param name='handlers'>
		/// Optional. The delegating handlers to add to the http client pipeline.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// Thrown when a required parameter is null
		/// </exception>
		public DirectLineClient (ServiceClientCredentials credentials, params DelegatingHandler [] handlers) : this (handlers)
		{
			if (credentials == null)
			{
				throw new System.ArgumentNullException ("credentials");
			}
			Credentials = credentials;
			if (Credentials != null)
			{
				Credentials.InitializeServiceClient (this);
			}
		}

		/// <summary>
		/// Initializes a new instance of the DirectLineClient class.
		/// </summary>
		/// <param name='credentials'>
		/// Required. Subscription credentials which uniquely identify client subscription.
		/// </param>
		/// <param name='rootHandler'>
		/// Optional. The http client handler used to handle http transport.
		/// </param>
		/// <param name='handlers'>
		/// Optional. The delegating handlers to add to the http client pipeline.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// Thrown when a required parameter is null
		/// </exception>
		public DirectLineClient (ServiceClientCredentials credentials, HttpClientHandler rootHandler, params DelegatingHandler [] handlers) : this (rootHandler, handlers)
		{
			if (credentials == null)
			{
				throw new System.ArgumentNullException ("credentials");
			}
			Credentials = credentials;
			if (Credentials != null)
			{
				Credentials.InitializeServiceClient (this);
			}
		}

		/// <summary>
		/// Initializes a new instance of the DirectLineClient class.
		/// </summary>
		/// <param name='baseUri'>
		/// Optional. The base URI of the service.
		/// </param>
		/// <param name='credentials'>
		/// Required. Subscription credentials which uniquely identify client subscription.
		/// </param>
		/// <param name='handlers'>
		/// Optional. The delegating handlers to add to the http client pipeline.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// Thrown when a required parameter is null
		/// </exception>
		public DirectLineClient (System.Uri baseUri, ServiceClientCredentials credentials, params DelegatingHandler [] handlers) : this (handlers)
		{
			if (baseUri == null)
			{
				throw new System.ArgumentNullException ("baseUri");
			}
			if (credentials == null)
			{
				throw new System.ArgumentNullException ("credentials");
			}
			BaseUri = baseUri;
			Credentials = credentials;
			if (Credentials != null)
			{
				Credentials.InitializeServiceClient (this);
			}
		}

		/// <summary>
		/// Initializes a new instance of the DirectLineClient class.
		/// </summary>
		/// <param name='baseUri'>
		/// Optional. The base URI of the service.
		/// </param>
		/// <param name='credentials'>
		/// Required. Subscription credentials which uniquely identify client subscription.
		/// </param>
		/// <param name='rootHandler'>
		/// Optional. The http client handler used to handle http transport.
		/// </param>
		/// <param name='handlers'>
		/// Optional. The delegating handlers to add to the http client pipeline.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// Thrown when a required parameter is null
		/// </exception>
		public DirectLineClient (System.Uri baseUri, ServiceClientCredentials credentials, HttpClientHandler rootHandler, params DelegatingHandler [] handlers) : this (rootHandler, handlers)
		{
			if (baseUri == null)
			{
				throw new System.ArgumentNullException ("baseUri");
			}
			if (credentials == null)
			{
				throw new System.ArgumentNullException ("credentials");
			}
			BaseUri = baseUri;
			Credentials = credentials;
			if (Credentials != null)
			{
				Credentials.InitializeServiceClient (this);
			}
		}

		/// <summary>
		/// An optional partial-method to perform custom initialization.
		///</summary>
		partial void CustomInitialize ();
		/// <summary>
		/// Initializes client properties.
		/// </summary>
		private void Initialize ()
		{
			Conversations = new Conversations (this);
			Tokens = new Tokens (this);
			BaseUri = new System.Uri ("https://directline.botframework.com");
			SerializationSettings = new JsonSerializerSettings
			{
				Formatting = Newtonsoft.Json.Formatting.Indented,
				DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
				DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
				NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
				ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
				ContractResolver = new ReadOnlyJsonContractResolver (),
				Converters = new List<JsonConverter>
					{
						new Iso8601TimeSpanConverter()
					}
			};
			DeserializationSettings = new JsonSerializerSettings
			{
				DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
				DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
				NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
				ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
				ContractResolver = new ReadOnlyJsonContractResolver (),
				Converters = new List<JsonConverter>
					{
						new Iso8601TimeSpanConverter()
					}
			};
			CustomInitialize ();
		}
	}
}
