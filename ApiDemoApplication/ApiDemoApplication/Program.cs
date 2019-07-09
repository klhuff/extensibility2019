using ApiDemoApplication.Data;
using ApiDemoApplication.Requests;
using D2L.Extensibility.AuthSdk.Restsharp;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Configuration;
using System.IO;

namespace ApiDemoApplication {
	internal sealed class Program {
		static void Main( string[] args ) {
			string appId = ConfigurationManager.AppSettings["applicationId"];
			string appKey = ConfigurationManager.AppSettings["applicationKey"];
			string userId = ConfigurationManager.AppSettings["serviceUserId"];
			string userKey = ConfigurationManager.AppSettings["serviceUserKey"];
			string lmsUrl = ConfigurationManager.AppSettings["lmsUrl"];

			ValenceAuthenticatorFactory authFactory = new ValenceAuthenticatorFactory(
				appId, appKey, userId, userKey, lmsUrl );
			ValenceAuthenticator auth = authFactory.CreateAuthenticator();

			RestClient restClient = new RestClient( "https://" + lmsUrl );

			JsonSerializer serializer = new JsonSerializer();
			CreateUserResponse userResponse;
			using ( StreamReader file = File.OpenText( "user.json" ) ) {
				CreateUserData userData = (CreateUserData)serializer.Deserialize( file, typeof( CreateUserData ) );
				CreateUserRequest userRequest = new CreateUserRequest(
					userData,
					restClient,
					auth
				);
				userResponse = userRequest.SendRequest();
			}

			CreateCourseResponse courseResponse;
			using ( StreamReader file = File.OpenText( "course.json" ) ) {
				CreateCourseData courseData = ( CreateCourseData )serializer.Deserialize( file, typeof( CreateCourseData ) );
				CreateCourseRequest courseRequest = new CreateCourseRequest(
					courseData,
					restClient,
					auth
				);
				courseResponse = courseRequest.SendRequest();
			}

			CreateEnrollData enrollData = new CreateEnrollData(
					userResponse.UserId,
					courseResponse.Identifier
				);
			CreateEnrollRequest enrollRequest = new CreateEnrollRequest(
					enrollData,
					restClient,
					auth
				);
			enrollRequest.SendRequest();

			Console.WriteLine( "User, course, and enrollment created." );
			Console.ReadKey();
		}

	}
}
