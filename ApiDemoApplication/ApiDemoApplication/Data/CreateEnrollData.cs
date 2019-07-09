using System;
using RestSharp.Serializers;

namespace ApiDemoApplication.Data {
	[Serializable]
	[SerializeAs( Name = "CreateEnrollData" )]
	internal sealed class CreateEnrollData {
		public CreateEnrollData(
				long userId,
				long orgUnitId
			) {
			UserId = userId;
			OrgUnitId = orgUnitId;
		}

		[SerializeAs(Name = "OrgUnitId")]
		public long OrgUnitId { get; }
		[SerializeAs(Name = "UserId")]
		public long UserId { get; }
		[SerializeAs(Name = "RoleId")]
		public int RoleId { get { return 101; } }
	}
}
