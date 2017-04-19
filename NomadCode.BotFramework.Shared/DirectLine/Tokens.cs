﻿
namespace NomadCode.BotFramework
{
	using Microsoft.Rest;
	using Newtonsoft.Json;
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;
	using System.Net;
	using System.Net.Http;
	using System.Threading;
	using System.Threading.Tasks;

	/// <summary>
	/// Tokens operations.
	/// </summary>
	public partial class Tokens : IServiceOperations<DirectLineClient>, ITokens
	{
		/// <summary>
		/// Initializes a new instance of the Tokens class.
		/// </summary>
		/// <param name='client'>
		/// Reference to the service client.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// Thrown when a required parameter is null
		/// </exception>
		public Tokens (DirectLineClient client)
		{
			if (client == null)
			{
				throw new System.ArgumentNullException ("client");
			}
			Client = client;
		}

		/// <summary>
		/// Gets a reference to the DirectLineClient
		/// </summary>
		public DirectLineClient Client { get; private set; }

		/// <summary>
		/// Refresh a token
		/// </summary>
		/// <param name='customHeaders'>
		/// Headers that will be added to request.
		/// </param>
		/// <param name='cancellationToken'>
		/// The cancellation token.
		/// </param>
		/// <exception cref="HttpOperationException">
		/// Thrown when the operation returned an invalid status code
		/// </exception>
		/// <exception cref="SerializationException">
		/// Thrown when unable to deserialize the response
		/// </exception>
		/// <return>
		/// A response object containing the response body and response headers.
		/// </return>
		public async Task<HttpOperationResponse<Conversation>> RefreshTokenWithHttpMessagesAsync (Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default (CancellationToken))
		{
			// Tracing
			bool _shouldTrace = ServiceClientTracing.IsEnabled;
			string _invocationId = null;
			if (_shouldTrace)
			{
				_invocationId = ServiceClientTracing.NextInvocationId.ToString ();
				Dictionary<string, object> tracingParameters = new Dictionary<string, object> ();
				tracingParameters.Add ("cancellationToken", cancellationToken);
				ServiceClientTracing.Enter (_invocationId, this, "RefreshToken", tracingParameters);
			}
			// Construct URL
			var _baseUrl = Client.BaseUri.AbsoluteUri;
			var _url = new System.Uri (new System.Uri (_baseUrl + (_baseUrl.EndsWith ("/") ? "" : "/")), "v3/directline/tokens/refresh").ToString ();
			// Create HTTP transport objects
			var _httpRequest = new HttpRequestMessage ();
			HttpResponseMessage _httpResponse = null;
			_httpRequest.Method = new HttpMethod ("POST");
			_httpRequest.RequestUri = new System.Uri (_url);
			// Set Headers


			if (customHeaders != null)
			{
				foreach (var _header in customHeaders)
				{
					if (_httpRequest.Headers.Contains (_header.Key))
					{
						_httpRequest.Headers.Remove (_header.Key);
					}
					_httpRequest.Headers.TryAddWithoutValidation (_header.Key, _header.Value);
				}
			}

			// Serialize Request
			string _requestContent = null;
			// Set Credentials
			if (Client.Credentials != null)
			{
				cancellationToken.ThrowIfCancellationRequested ();
				await Client.Credentials.ProcessHttpRequestAsync (_httpRequest, cancellationToken).ConfigureAwait (false);
			}
			// Send Request
			if (_shouldTrace)
			{
				ServiceClientTracing.SendRequest (_invocationId, _httpRequest);
			}
			cancellationToken.ThrowIfCancellationRequested ();
			_httpResponse = await Client.HttpClient.SendAsync (_httpRequest, cancellationToken).ConfigureAwait (false);
			if (_shouldTrace)
			{
				ServiceClientTracing.ReceiveResponse (_invocationId, _httpResponse);
			}
			HttpStatusCode _statusCode = _httpResponse.StatusCode;
			cancellationToken.ThrowIfCancellationRequested ();
			string _responseContent = null;
			if ((int)_statusCode != 200 && (int)_statusCode != 401 && (int)_statusCode != 403 && (int)_statusCode != 404 && (int)_statusCode != 500)
			{
				var ex = new HttpOperationException (string.Format ("Operation returned an invalid status code '{0}'", _statusCode));
				if (_httpResponse.Content != null)
				{
					_responseContent = await _httpResponse.Content.ReadAsStringAsync ().ConfigureAwait (false);
				}
				else
				{
					_responseContent = string.Empty;
				}
				ex.Request = new HttpRequestMessageWrapper (_httpRequest, _requestContent);
				ex.Response = new HttpResponseMessageWrapper (_httpResponse, _responseContent);
				if (_shouldTrace)
				{
					ServiceClientTracing.Error (_invocationId, ex);
				}
				_httpRequest.Dispose ();
				if (_httpResponse != null)
				{
					_httpResponse.Dispose ();
				}
				throw ex;
			}
			// Create Result
			var _result = new HttpOperationResponse<Conversation> ();
			_result.Request = _httpRequest;
			_result.Response = _httpResponse;
			// Deserialize Response
			if ((int)_statusCode == 200)
			{
				_responseContent = await _httpResponse.Content.ReadAsStringAsync ().ConfigureAwait (false);
				try
				{
					_result.Body = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<Conversation> (_responseContent, Client.DeserializationSettings);
				}
				catch (JsonException ex)
				{
					_httpRequest.Dispose ();
					if (_httpResponse != null)
					{
						_httpResponse.Dispose ();
					}
					throw new SerializationException ("Unable to deserialize the response.", _responseContent, ex);
				}
			}
			if (_shouldTrace)
			{
				ServiceClientTracing.Exit (_invocationId, _result);
			}
			return _result;
		}

		/// <summary>
		/// Generate a token for a new conversation
		/// </summary>
		/// <param name='customHeaders'>
		/// Headers that will be added to request.
		/// </param>
		/// <param name='cancellationToken'>
		/// The cancellation token.
		/// </param>
		/// <exception cref="HttpOperationException">
		/// Thrown when the operation returned an invalid status code
		/// </exception>
		/// <exception cref="SerializationException">
		/// Thrown when unable to deserialize the response
		/// </exception>
		/// <return>
		/// A response object containing the response body and response headers.
		/// </return>
		public async Task<HttpOperationResponse<Conversation>> GenerateTokenForNewConversationWithHttpMessagesAsync (Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default (CancellationToken))
		{
			// Tracing
			bool _shouldTrace = ServiceClientTracing.IsEnabled;
			string _invocationId = null;
			if (_shouldTrace)
			{
				_invocationId = ServiceClientTracing.NextInvocationId.ToString ();
				Dictionary<string, object> tracingParameters = new Dictionary<string, object> ();
				tracingParameters.Add ("cancellationToken", cancellationToken);
				ServiceClientTracing.Enter (_invocationId, this, "GenerateTokenForNewConversation", tracingParameters);
			}
			// Construct URL
			var _baseUrl = Client.BaseUri.AbsoluteUri;
			var _url = new System.Uri (new System.Uri (_baseUrl + (_baseUrl.EndsWith ("/") ? "" : "/")), "v3/directline/tokens/generate").ToString ();
			// Create HTTP transport objects
			var _httpRequest = new HttpRequestMessage ();
			HttpResponseMessage _httpResponse = null;
			_httpRequest.Method = new HttpMethod ("POST");
			_httpRequest.RequestUri = new System.Uri (_url);
			// Set Headers


			if (customHeaders != null)
			{
				foreach (var _header in customHeaders)
				{
					if (_httpRequest.Headers.Contains (_header.Key))
					{
						_httpRequest.Headers.Remove (_header.Key);
					}
					_httpRequest.Headers.TryAddWithoutValidation (_header.Key, _header.Value);
				}
			}

			// Serialize Request
			string _requestContent = null;
			// Set Credentials
			if (Client.Credentials != null)
			{
				cancellationToken.ThrowIfCancellationRequested ();
				await Client.Credentials.ProcessHttpRequestAsync (_httpRequest, cancellationToken).ConfigureAwait (false);
			}
			// Send Request
			if (_shouldTrace)
			{
				ServiceClientTracing.SendRequest (_invocationId, _httpRequest);
			}
			cancellationToken.ThrowIfCancellationRequested ();
			_httpResponse = await Client.HttpClient.SendAsync (_httpRequest, cancellationToken).ConfigureAwait (false);
			if (_shouldTrace)
			{
				ServiceClientTracing.ReceiveResponse (_invocationId, _httpResponse);
			}
			HttpStatusCode _statusCode = _httpResponse.StatusCode;
			cancellationToken.ThrowIfCancellationRequested ();
			string _responseContent = null;
			if ((int)_statusCode != 200 && (int)_statusCode != 401 && (int)_statusCode != 403 && (int)_statusCode != 404 && (int)_statusCode != 500)
			{
				var ex = new HttpOperationException (string.Format ("Operation returned an invalid status code '{0}'", _statusCode));
				if (_httpResponse.Content != null)
				{
					_responseContent = await _httpResponse.Content.ReadAsStringAsync ().ConfigureAwait (false);
				}
				else
				{
					_responseContent = string.Empty;
				}
				ex.Request = new HttpRequestMessageWrapper (_httpRequest, _requestContent);
				ex.Response = new HttpResponseMessageWrapper (_httpResponse, _responseContent);
				if (_shouldTrace)
				{
					ServiceClientTracing.Error (_invocationId, ex);
				}
				_httpRequest.Dispose ();
				if (_httpResponse != null)
				{
					_httpResponse.Dispose ();
				}
				throw ex;
			}
			// Create Result
			var _result = new HttpOperationResponse<Conversation> ();
			_result.Request = _httpRequest;
			_result.Response = _httpResponse;
			// Deserialize Response
			if ((int)_statusCode == 200)
			{
				_responseContent = await _httpResponse.Content.ReadAsStringAsync ().ConfigureAwait (false);
				try
				{
					_result.Body = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<Conversation> (_responseContent, Client.DeserializationSettings);
				}
				catch (JsonException ex)
				{
					_httpRequest.Dispose ();
					if (_httpResponse != null)
					{
						_httpResponse.Dispose ();
					}
					throw new SerializationException ("Unable to deserialize the response.", _responseContent, ex);
				}
			}
			if (_shouldTrace)
			{
				ServiceClientTracing.Exit (_invocationId, _result);
			}
			return _result;
		}

	}
}
