using System;
using RestSharp.Serializers;

namespace ApiDemoApplication.Data {
	[Serializable]
	[SerializeAs( Name = "CreateCourseData" )]
	internal sealed class CreateCourseData {
		public CreateCourseData(
				string name,
				string code
			) {
			Name = name;
			Code = code;
		}

		[SerializeAs(Name = "Name")]
		public string Name { get; }
		[SerializeAs(Name = "Code")]
		public string Code { get; }
		[SerializeAs(Name = "Path")]
		public string Path { get { return null; } }
		[SerializeAs(Name = "CourseTemplateId")]
		public long CourseTemplateId { get { return 6608; } }
		[SerializeAs(Name = "SemesterId")]
		public string SemesterId { get { return null; } }
		[SerializeAs(Name = "StartDate")]
		public string StartDate { get { return null; } }
		[SerializeAs(Name = "EndDate")]
		public string EndDate { get { return null; } }
		[SerializeAs(Name = "LocaleId")]
		public string LocaleId { get { return null; } }
		[SerializeAs(Name = "ForceLocale")]
		public bool ForceLocale { get { return false; } }
		[SerializeAs(Name = "ShowAddressBook")]
		public bool ShowAddressBook { get { return false; } }
	}
}
