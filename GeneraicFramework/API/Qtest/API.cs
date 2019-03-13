using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TxAutomateFramework.API;

namespace GenericFramework.API.QTest
{
    public interface ILoginApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Log in
        /// </summary>
        /// <remarks>
        /// To authenticate the API client against qTest Manager and acquire authorized access token.    Note: Please choose parameter &lt;em&gt;content-type&#x3D;application/x-www-form-urlencoded&lt;/em&gt;
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="grantType">always use &lt;em&gt;grant_type&#x3D;password&lt;/em&gt; (optional, default to password)</param>
        /// <param name="username">Your qTest Manager username (optional)</param>
        /// <param name="password">Your qTest Manager password (optional)</param>
        /// <param name="authorization">Basic + [base64 string of \&quot;&lt;strong&gt;your qTest site name and colon&lt;/strong&gt;\&quot;]  Example: qTest Manager site is: apitryout.qtestnet.com then site name is: apitryout + &#39;:&#39;, then Authorization is: Basic YXBpdHJ5b3V0Og&#x3D;&#x3D; (optional)</param>
        /// <returns>OAuthResponse</returns>
        OAuthResponse PostAccessToken(string grantType = null, string username = null, string password = null, string authorization = null);

        /// <summary>
        /// Log in
        /// </summary>
        /// <remarks>
        /// To authenticate the API client against qTest Manager and acquire authorized access token.    Note: Please choose parameter &lt;em&gt;content-type&#x3D;application/x-www-form-urlencoded&lt;/em&gt;
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="grantType">always use &lt;em&gt;grant_type&#x3D;password&lt;/em&gt; (optional, default to password)</param>
        /// <param name="username">Your qTest Manager username (optional)</param>
        /// <param name="password">Your qTest Manager password (optional)</param>
        /// <param name="authorization">Basic + [base64 string of \&quot;&lt;strong&gt;your qTest site name and colon&lt;/strong&gt;\&quot;]  Example: qTest Manager site is: apitryout.qtestnet.com then site name is: apitryout + &#39;:&#39;, then Authorization is: Basic YXBpdHJ5b3V0Og&#x3D;&#x3D; (optional)</param>
        /// <returns>ApiResponse of OAuthResponse</returns>
        ApiResponse<OAuthResponse> PostAccessTokenWithHttpInfo(string grantType = null, string username = null, string password = null, string authorization = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Log in
        /// </summary>
        /// <remarks>
        /// To authenticate the API client against qTest Manager and acquire authorized access token.    Note: Please choose parameter &lt;em&gt;content-type&#x3D;application/x-www-form-urlencoded&lt;/em&gt;
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="grantType">always use &lt;em&gt;grant_type&#x3D;password&lt;/em&gt; (optional, default to password)</param>
        /// <param name="username">Your qTest Manager username (optional)</param>
        /// <param name="password">Your qTest Manager password (optional)</param>
        /// <param name="authorization">Basic + [base64 string of \&quot;&lt;strong&gt;your qTest site name and colon&lt;/strong&gt;\&quot;]  Example: qTest Manager site is: apitryout.qtestnet.com then site name is: apitryout + &#39;:&#39;, then Authorization is: Basic YXBpdHJ5b3V0Og&#x3D;&#x3D; (optional)</param>
        /// <returns>Task of OAuthResponse</returns>
        System.Threading.Tasks.Task<OAuthResponse> PostAccessTokenAsync(string grantType = null, string username = null, string password = null, string authorization = null);

        /// <summary>
        /// Log in
        /// </summary>
        /// <remarks>
        /// To authenticate the API client against qTest Manager and acquire authorized access token.    Note: Please choose parameter &lt;em&gt;content-type&#x3D;application/x-www-form-urlencoded&lt;/em&gt;
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="grantType">always use &lt;em&gt;grant_type&#x3D;password&lt;/em&gt; (optional, default to password)</param>
        /// <param name="username">Your qTest Manager username (optional)</param>
        /// <param name="password">Your qTest Manager password (optional)</param>
        /// <param name="authorization">Basic + [base64 string of \&quot;&lt;strong&gt;your qTest site name and colon&lt;/strong&gt;\&quot;]  Example: qTest Manager site is: apitryout.qtestnet.com then site name is: apitryout + &#39;:&#39;, then Authorization is: Basic YXBpdHJ5b3V0Og&#x3D;&#x3D; (optional)</param>
        /// <returns>Task of ApiResponse (OAuthResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<OAuthResponse>> PostAccessTokenAsyncWithHttpInfo(string grantType = null, string username = null, string password = null, string authorization = null);
        #endregion Asynchronous Operations
    }
	public partial class APIClass : ILoginApi
	{
		private ExceptionFactory _exceptionFactory = (name, response) => null;

		/// <summary>
		/// Initializes a new instance of the <see cref="LoginApi"/> class.
		/// </summary>
		/// <returns></returns>
		public APIClass(String basePath)
		{
			this.Configuration = new Configuration(new ApiClient(basePath));

			ExceptionFactory = Configuration.DefaultExceptionFactory;

			// ensure API client has configuration ready
			if (Configuration.ApiClient.Configuration == null)
			{
				this.Configuration.ApiClient.Configuration = this.Configuration;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LoginApi"/> class
		/// using Configuration object
		/// </summary>
		/// <param name="configuration">An instance of Configuration</param>
		/// <returns></returns>
		public APIClass(Configuration configuration = null)
		{
			if (configuration == null) // use the default one in Configuration
				this.Configuration = Configuration.Default;
			else
				this.Configuration = configuration;

			ExceptionFactory = Configuration.DefaultExceptionFactory;

			// ensure API client has configuration ready
			if (Configuration.ApiClient.Configuration == null)
			{
				this.Configuration.ApiClient.Configuration = this.Configuration;
			}
		}

		/// <summary>
		/// Gets the base path of the API client.
		/// </summary>
		/// <value>The base path</value>
		public String GetBasePath()
		{
			return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
		}

		/// <summary>
		/// Sets the base path of the API client.
		/// </summary>
		/// <value>The base path</value>
		[Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
		public void SetBasePath(String basePath)
		{
			// do nothing
		}

		/// <summary>
		/// Gets or sets the configuration object
		/// </summary>
		/// <value>An instance of the Configuration</value>
		public Configuration Configuration { get; set; }

		/// <summary>
		/// Provides a factory method hook for the creation of exceptions.
		/// </summary>
		public ExceptionFactory ExceptionFactory
		{
			get
			{
				if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
				{
					throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
				}
				return _exceptionFactory;
			}
			set { _exceptionFactory = value; }
		}

		/// <summary>
		/// Gets the default header.
		/// </summary>
		/// <returns>Dictionary of HTTP header</returns>
		[Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
		public Dictionary<String, String> DefaultHeader()
		{
			return this.Configuration.DefaultHeader;
		}

		/// <summary>
		/// Add default header.
		/// </summary>
		/// <param name="key">Header field name.</param>
		/// <param name="value">Header field value.</param>
		/// <returns></returns>
		[Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
		public void AddDefaultHeader(string key, string value)
		{
			this.Configuration.AddDefaultHeader(key, value);
		}

		/// <summary>
		/// Log in To authenticate the API client against qTest Manager and acquire authorized access token.    Note: Please choose parameter &lt;em&gt;content-type&#x3D;application/x-www-form-urlencoded&lt;/em&gt;
		/// </summary>
		/// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
		/// <param name="grantType">always use &lt;em&gt;grant_type&#x3D;password&lt;/em&gt; (optional, default to password)</param>
		/// <param name="username">Your qTest Manager username (optional)</param>
		/// <param name="password">Your qTest Manager password (optional)</param>
		/// <param name="authorization">Basic + [base64 string of \&quot;&lt;strong&gt;your qTest site name and colon&lt;/strong&gt;\&quot;]  Example: qTest Manager site is: apitryout.qtestnet.com then site name is: apitryout + &#39;:&#39;, then Authorization is: Basic YXBpdHJ5b3V0Og&#x3D;&#x3D; (optional)</param>
		/// <returns>OAuthResponse</returns>
		public OAuthResponse PostAccessToken(string grantType = null, string username = null, string password = null, string authorization = null)
		{
			ApiResponse<OAuthResponse> localVarResponse = PostAccessTokenWithHttpInfo(grantType, username, password, authorization);
			return localVarResponse.Data;
		}

		/// <summary>
		/// Log in To authenticate the API client against qTest Manager and acquire authorized access token.    Note: Please choose parameter &lt;em&gt;content-type&#x3D;application/x-www-form-urlencoded&lt;/em&gt;
		/// </summary>
		/// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
		/// <param name="grantType">always use &lt;em&gt;grant_type&#x3D;password&lt;/em&gt; (optional, default to password)</param>
		/// <param name="username">Your qTest Manager username (optional)</param>
		/// <param name="password">Your qTest Manager password (optional)</param>
		/// <param name="authorization">Basic + [base64 string of \&quot;&lt;strong&gt;your qTest site name and colon&lt;/strong&gt;\&quot;]  Example: qTest Manager site is: apitryout.qtestnet.com then site name is: apitryout + &#39;:&#39;, then Authorization is: Basic YXBpdHJ5b3V0Og&#x3D;&#x3D; (optional)</param>
		/// <returns>ApiResponse of OAuthResponse</returns>
		public ApiResponse<OAuthResponse> PostAccessTokenWithHttpInfo(string grantType = null, string username = null, string password = null, string authorization = null)
		{

			var localVarPath = "http://vldemo.qtestnet.com//oauth/token";
			var localVarPathParams = new Dictionary<String, String>();
			var localVarQueryParams = new Dictionary<String, String>();
			var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
			var localVarFormParams = new Dictionary<String, String>();
			var localVarFileParams = new Dictionary<String, FileParameter>();
			Object localVarPostBody = null;

			// to determine the Content-Type header
			String[] localVarHttpContentTypes = new String[] {
				"application/x-www-form-urlencoded"
			};
			String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

			// to determine the Accept header
			String[] localVarHttpHeaderAccepts = new String[] {
			};
			String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
			if (localVarHttpHeaderAccept != null)
				localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

			// set "format" to json by default
			// e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
			localVarPathParams.Add("format", "json");
			if (authorization != null) localVarHeaderParams.Add("Authorization", Configuration.ApiClient.ParameterToString(authorization)); // header parameter
			if (grantType != null) localVarFormParams.Add("grant_type", Configuration.ApiClient.ParameterToString(grantType)); // form parameter
			if (username != null) localVarFormParams.Add("username", Configuration.ApiClient.ParameterToString(username)); // form parameter
			if (password != null) localVarFormParams.Add("password", Configuration.ApiClient.ParameterToString(password)); // form parameter


			// make the HTTP request
			IRestResponse localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
				Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
				localVarPathParams, localVarHttpContentType);

			int localVarStatusCode = (int)localVarResponse.StatusCode;

			if (ExceptionFactory != null)
			{
				Exception exception = ExceptionFactory("PostAccessToken", localVarResponse);
				if (exception != null) throw exception;
			}

			return new ApiResponse<OAuthResponse>(localVarStatusCode,
				localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
				(OAuthResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(OAuthResponse)));

		}

		/// <summary>
		/// Log in To authenticate the API client against qTest Manager and acquire authorized access token.    Note: Please choose parameter &lt;em&gt;content-type&#x3D;application/x-www-form-urlencoded&lt;/em&gt;
		/// </summary>
		/// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
		/// <param name="grantType">always use &lt;em&gt;grant_type&#x3D;password&lt;/em&gt; (optional, default to password)</param>
		/// <param name="username">Your qTest Manager username (optional)</param>
		/// <param name="password">Your qTest Manager password (optional)</param>
		/// <param name="authorization">Basic + [base64 string of \&quot;&lt;strong&gt;your qTest site name and colon&lt;/strong&gt;\&quot;]  Example: qTest Manager site is: apitryout.qtestnet.com then site name is: apitryout + &#39;:&#39;, then Authorization is: Basic YXBpdHJ5b3V0Og&#x3D;&#x3D; (optional)</param>
		/// <returns>Task of OAuthResponse</returns>
		public async System.Threading.Tasks.Task<OAuthResponse> PostAccessTokenAsync(string grantType = null, string username = null, string password = null, string authorization = null)
		{
			ApiResponse<OAuthResponse> localVarResponse = await PostAccessTokenAsyncWithHttpInfo(grantType, username, password, authorization);
			return localVarResponse.Data;

		}

		/// <summary>
		/// Log in To authenticate the API client against qTest Manager and acquire authorized access token.    Note: Please choose parameter &lt;em&gt;content-type&#x3D;application/x-www-form-urlencoded&lt;/em&gt;
		/// </summary>
		/// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
		/// <param name="grantType">always use &lt;em&gt;grant_type&#x3D;password&lt;/em&gt; (optional, default to password)</param>
		/// <param name="username">Your qTest Manager username (optional)</param>
		/// <param name="password">Your qTest Manager password (optional)</param>
		/// <param name="authorization">Basic + [base64 string of \&quot;&lt;strong&gt;your qTest site name and colon&lt;/strong&gt;\&quot;]  Example: qTest Manager site is: apitryout.qtestnet.com then site name is: apitryout + &#39;:&#39;, then Authorization is: Basic YXBpdHJ5b3V0Og&#x3D;&#x3D; (optional)</param>
		/// <returns>Task of ApiResponse (OAuthResponse)</returns>
		public async System.Threading.Tasks.Task<ApiResponse<OAuthResponse>> PostAccessTokenAsyncWithHttpInfo(string grantType = null, string username = null, string password = null, string authorization = null)
		{

			var localVarPath = "/oauth/token";
			var localVarPathParams = new Dictionary<String, String>();
			var localVarQueryParams = new Dictionary<String, String>();
			var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
			var localVarFormParams = new Dictionary<String, String>();
			var localVarFileParams = new Dictionary<String, FileParameter>();
			Object localVarPostBody = null;

			// to determine the Content-Type header
			String[] localVarHttpContentTypes = new String[] {
				"application/x-www-form-urlencoded"
			};
			String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

			// to determine the Accept header
			String[] localVarHttpHeaderAccepts = new String[] {
			};
			String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
			if (localVarHttpHeaderAccept != null)
				localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

			// set "format" to json by default
			// e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
			localVarPathParams.Add("format", "json");
			if (authorization != null) localVarHeaderParams.Add("Authorization", Configuration.ApiClient.ParameterToString(authorization)); // header parameter
			if (grantType != null) localVarFormParams.Add("grant_type", Configuration.ApiClient.ParameterToString(grantType)); // form parameter
			if (username != null) localVarFormParams.Add("username", Configuration.ApiClient.ParameterToString(username)); // form parameter
			if (password != null) localVarFormParams.Add("password", Configuration.ApiClient.ParameterToString(password)); // form parameter


			// make the HTTP request
			IRestResponse localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
				Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
				localVarPathParams, localVarHttpContentType);

			int localVarStatusCode = (int)localVarResponse.StatusCode;

			if (ExceptionFactory != null)
			{
				Exception exception = ExceptionFactory("PostAccessToken", localVarResponse);
				if (exception != null) throw exception;
			}

			return new ApiResponse<OAuthResponse>(localVarStatusCode,
				localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
				(OAuthResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(OAuthResponse)));

		}

		//public ApiResponse<AutomationTestLogResource> SubmitAutomationLogWithHttpInfo(long? projectId, AutomationTestLogResource body, long? testRunId, string suitePerDay = null, string suiteDate = null, bool? encodeNote = null, bool? forceUpdateVersion = null, string agentId = null, string userId = null)
		//{
		//	// verify the required parameter 'projectId' is set
		//	if (projectId == null)
		//		throw new ApiException(400, "Missing required parameter 'projectId' when calling TestlogApi->SubmitAutomationLog");
		//	// verify the required parameter 'body' is set
		//	if (body == null)
		//		throw new ApiException(400, "Missing required parameter 'body' when calling TestlogApi->SubmitAutomationLog");
		//	// verify the required parameter 'testRunId' is set
		//	if (testRunId == null)
		//		throw new ApiException(400, "Missing required parameter 'testRunId' when calling TestlogApi->SubmitAutomationLog");
		//	StringBuilder str = new StringBuilder();
		//	var localVarPath = str.AppendFormat("http://vldemo.qtestnet.com/api/v3/projects/{0}/test-runs/{1}/auto-test-logs",projectId.ToString(), 0).ToString();
		//	var localVarPathParams = new Dictionary<String, String>();
		//	var localVarQueryParams = new Dictionary<String, String>();
		//	var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
		//	var localVarFormParams = new Dictionary<String, String>();
		//	var localVarFileParams = new Dictionary<String, FileParameter>();
		//	Object localVarPostBody = null;

		//	// to determine the Content-Type header
		//	String[] localVarHttpContentTypes = new String[] {
		//	};
		//	String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

		//	// to determine the Accept header
		//	String[] localVarHttpHeaderAccepts = new String[] {
		//	};
		//	String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
		//	if (localVarHttpHeaderAccept != null)
		//		localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

		//	// set "format" to json by default
		//	// e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
		//	localVarPathParams.Add("format", "json");
		//	if (projectId != null) localVarPathParams.Add("projectId", Configuration.ApiClient.ParameterToString(projectId)); // path parameter
		//	if (testRunId != null) localVarPathParams.Add("testRunId", Configuration.ApiClient.ParameterToString(0)); // path parameter
		//	if (suitePerDay != null) localVarQueryParams.Add("suitePerDay", Configuration.ApiClient.ParameterToString(suitePerDay)); // query parameter
		//	if (suiteDate != null) localVarQueryParams.Add("suiteDate", Configuration.ApiClient.ParameterToString(suiteDate)); // query parameter
		//	if (encodeNote != null) localVarQueryParams.Add("encodeNote", Configuration.ApiClient.ParameterToString(encodeNote)); // query parameter
		//	if (forceUpdateVersion != null) localVarQueryParams.Add("forceUpdateVersion", Configuration.ApiClient.ParameterToString(forceUpdateVersion)); // query parameter
		//	if (agentId != null) localVarQueryParams.Add("agentId", Configuration.ApiClient.ParameterToString(agentId)); // query parameter
		//	if (userId != null) localVarQueryParams.Add("userId", Configuration.ApiClient.ParameterToString(userId)); // query parameter
		//	if (body != null && body.GetType() != typeof(byte[]))
		//	{
		//		localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
		//	}
		//	else
		//	{
		//		localVarPostBody = body; // byte array
		//	}

		//	// authentication (Authorization) required
		//	//if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
		//	//{
		//	//	localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
		//	//}

		//	localVarHeaderParams["Authorization"] = "Bearer bfbff69c-4bea-468a-9446-c44ccdd3dd5e";
		//	// make the HTTP request
		//	IRestResponse localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
		//		Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
		//		localVarPathParams, localVarHttpContentType);

		//	int localVarStatusCode = (int)localVarResponse.StatusCode;

		//	if (ExceptionFactory != null)
		//	{
		//		Exception exception = ExceptionFactory("SubmitAutomationLog", localVarResponse);
		//		if (exception != null) throw exception;
		//	}

		//	return new ApiResponse<AutomationTestLogResource>(localVarStatusCode,
		//		localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
		//		(AutomationTestLogResource)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AutomationTestLogResource)));

		//}
		//public AutomationTestLogResource SubmitAutomationLog(long? projectId, AutomationTestLogResource body, long? testRunId, string suitePerDay = null, string suiteDate = null, bool? encodeNote = null, bool? forceUpdateVersion = null, string agentId = null, string userId = null)
		//{
		//	ApiResponse<AutomationTestLogResource> localVarResponse = SubmitAutomationLogWithHttpInfo(projectId, body, testRunId, suitePerDay, suiteDate, encodeNote, forceUpdateVersion, agentId, userId);
		//	return localVarResponse.Data;
		//}

		public QueueProcessingResponse SubmitAutomationTestLogs(long? projectId, AutomationRequest body, string type, long? testRunId, bool? escapeXml = null, string userId = null)
		{
			ApiResponse<QueueProcessingResponse> localVarResponse = SubmitAutomationTestLogsWithHttpInfo(projectId, body, type, testRunId, escapeXml, userId);
			return localVarResponse.Data;
		}

        public ApiResponse<QueueProcessingResponse> SubmitAutomationTestLogsWithHttpInfo(long? projectId, AutomationRequest body, string type, long? testRunId, bool? escapeXml = null, string userId = null)
		{
			// verify the required parameter 'projectId' is set
			if (projectId == null)
				throw new ApiException(400, "Missing required parameter 'projectId' when calling TestlogApi->SubmitAutomationTestLogs");
			// verify the required parameter 'body' is set
			if (body == null)
				throw new ApiException(400, "Missing required parameter 'body' when calling TestlogApi->SubmitAutomationTestLogs");
			// verify the required parameter 'type' is set
			if (type == null)
				throw new ApiException(400, "Missing required parameter 'type' when calling TestlogApi->SubmitAutomationTestLogs");
			// verify the required parameter 'testRunId' is set
			if (testRunId == null)
				throw new ApiException(400, "Missing required parameter 'testRunId' when calling TestlogApi->SubmitAutomationTestLogs");
			StringBuilder str = new StringBuilder();
			var localVarPath = str.AppendFormat("http://visuallease.qtestnet.com/api/v3.1/projects/{0}/test-runs/{1}/auto-test-logs", projectId.ToString(), 0).ToString(); 
			var localVarPathParams = new Dictionary<String, String>();
			var localVarQueryParams = new Dictionary<String, String>();
			var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
			var localVarFormParams = new Dictionary<String, String>();
			var localVarFileParams = new Dictionary<String, FileParameter>();
			Object localVarPostBody = null;

			// to determine the Content-Type header
			String[] localVarHttpContentTypes = new String[] {
			};
			String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

			// to determine the Accept header
			String[] localVarHttpHeaderAccepts = new String[] {
			};
			String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
			if (localVarHttpHeaderAccept != null)
				localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

			// set "format" to json by default
			// e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
			localVarPathParams.Add("format", "json");
			if (projectId != null) localVarPathParams.Add("projectId", Configuration.ApiClient.ParameterToString(projectId)); // path parameter
			if (testRunId != null) localVarPathParams.Add("testRunId", Configuration.ApiClient.ParameterToString(testRunId)); // path parameter
			if (type != null) localVarQueryParams.Add("type", Configuration.ApiClient.ParameterToString(type)); // query parameter
			if (escapeXml != null) localVarQueryParams.Add("escapeXml", Configuration.ApiClient.ParameterToString(escapeXml)); // query parameter
			if (userId != null) localVarQueryParams.Add("userId", Configuration.ApiClient.ParameterToString(userId)); // query parameter
			if (body != null && body.GetType() != typeof(byte[]))
			{
				localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
			}
			else
			{
				localVarPostBody = body; // byte array
			}

            // authentication (Authorization) required
            //if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            //{
            //	localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            //}
            localVarHeaderParams["Authorization"] = "Bearer 7e873b36-f357-4c3e-998a-0bed92ea87e7";

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
				Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
				localVarPathParams, localVarHttpContentType);

			int localVarStatusCode = (int)localVarResponse.StatusCode;

			if (ExceptionFactory != null)
			{
				Exception exception = ExceptionFactory("SubmitAutomationTestLogs", localVarResponse);
				if (exception != null) { Console.WriteLine(exception); }
			}

			return new ApiResponse<QueueProcessingResponse>(localVarStatusCode,
				localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
				(QueueProcessingResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(QueueProcessingResponse)));

		}
	}
}
