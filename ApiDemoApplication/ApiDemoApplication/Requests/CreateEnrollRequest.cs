using ApiDemoApplication.Data;
using D2L.Extensibility.AuthSdk.Restsharp;
using RestSharp;

namespace ApiDemoApplication.Requests {
	internal sealed class CreateEnrollRequest {
		private const string CreateEnrollUrl = "/d2l/api/lp/1.19/enrollments/";

		private readonly CreateEnrollData m_enrollData;
		private readonly IRestClient m_restClient;
		private readonly ValenceAuthenticator m_auth;

		public CreateEnrollRequest(
				CreateEnrollData data,
				IRestClient restClient,
				ValenceAuthenticator auth
			) {
			m_enrollData = data;
			m_restClient = restClient;
			m_auth = auth;
		}

		public void SendRequest() {
			RestRequest request = new RestRequest( CreateEnrollUrl, Method.POST );
			request.RequestFormat = DataFormat.Json;
			request.AddBody( m_enrollData );

			m_auth.Authenticate( m_restClient, request );
			m_restClient.Execute( request );
		}
	}
}
