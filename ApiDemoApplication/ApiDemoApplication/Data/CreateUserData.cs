using System;
using RestSharp.Serializers;

namespace ApiDemoApplication.Data {
	[Serializable]
	[SerializeAs( Name = "CreateUserData" )]
	internal sealed class CreateUserData {
		public CreateUserData(
				string orgDefinedId,
				string firstName,
				string lastName,
				string userName
			) {
			OrgDefinedId = orgDefinedId;
			FirstName = firstName;
			LastName = lastName;
			UserName = userName;
		}

		[SerializeAs(Name = "OrgDefinedId")]
		public string OrgDefinedId { get; }
		[SerializeAs(Name = "FirstName")]
		public string FirstName { get; }
		[SerializeAs(Name = "MiddleName")]
		public string MiddleName { get { return null; } }
		[SerializeAs(Name = "LastName")]
		public string LastName { get; }
		[SerializeAs(Name = "ExternalEmail")]
		public string ExternalEmail { get { return null; } }
		[SerializeAs(Name = "UserName")]
		public string UserName { get; }
		[SerializeAs(Name = "RoleId")]
		public int RoleId { get { return 101; } }
		[SerializeAs(Name = "IsActive")]
		public bool IsActive { get { return true; } }
		[SerializeAs(Name = "SendCreationEmail")]
		public bool SendCreationEmail { get { return false; } }
	}
}
