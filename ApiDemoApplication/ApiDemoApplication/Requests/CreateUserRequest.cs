using ApiDemoApplication.Data;
using D2L.Extensibility.AuthSdk.Restsharp;
using RestSharp;

namespace ApiDemoApplication.Requests {
	internal sealed class CreateUserRequest {
		private const string CreateUserUrl = "/d2l/api/lp/1.19/users/";

		private readonly CreateUserData m_userData;
		private readonly IRestClient m_restClient;
		private readonly ValenceAuthenticator m_auth;

		public CreateUserRequest(
				CreateUserData data,
				IRestClient restClient,
				ValenceAuthenticator auth
			) {
			m_userData = data;
			m_restClient = restClient;
			m_auth = auth;
		}

		public CreateUserResponse SendRequest() {
			RestRequest request = new RestRequest( CreateUserUrl, Method.POST );
			request.RequestFormat = DataFormat.Json;
			request.AddBody( m_userData );
			

			m_auth.Authenticate( m_restClient, request );
			IRestResponse<CreateUserResponse> response = m_restClient.Execute<CreateUserResponse>( request );
			return response.Data;
		}
	}
}
