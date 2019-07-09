using ApiDemoApplication.Data;
using D2L.Extensibility.AuthSdk.Restsharp;
using RestSharp;

namespace ApiDemoApplication.Requests {
	internal sealed class CreateCourseRequest {
		private const string CreateCourseUrl = "/d2l/api/lp/1.19/courses/";

		private readonly CreateCourseData m_courseData;
		private readonly IRestClient m_restClient;
		private readonly ValenceAuthenticator m_auth;

		public CreateCourseRequest(
				CreateCourseData data,
				IRestClient restClient,
				ValenceAuthenticator auth
			) {
			m_courseData = data;
			m_restClient = restClient;
			m_auth = auth;
		}

		public CreateCourseResponse SendRequest() {
			RestRequest request = new RestRequest( CreateCourseUrl, Method.POST );
			request.RequestFormat = DataFormat.Json;
			request.AddBody( m_courseData );
			

			m_auth.Authenticate( m_restClient, request );
			IRestResponse<CreateCourseResponse> response = m_restClient.Execute<CreateCourseResponse>( request );
			return response.Data;
		}
	}
}
