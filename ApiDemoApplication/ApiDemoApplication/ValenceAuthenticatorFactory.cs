using D2L.Extensibility.AuthSdk;
using D2L.Extensibility.AuthSdk.Restsharp;

namespace ApiDemoApplication {
	internal sealed class ValenceAuthenticatorFactory {

		private readonly string m_appId;
		private readonly string m_appKey;
		private readonly string m_userId;
		private readonly string m_userKey;
		private readonly string m_lmsUrl;

		public ValenceAuthenticatorFactory(
				string appId,
				string appKey,
				string userId,
				string userKey,
				string lmsUrl
			) {
			m_appId = appId;
			m_appKey = appKey;
			m_userId = userId;
			m_userKey = userKey;
			m_lmsUrl = lmsUrl;
		}

		public ValenceAuthenticator CreateAuthenticator() {
			D2LAppContextFactory contextFactory = new D2LAppContextFactory();
			ID2LAppContext appContext = contextFactory.Create( m_appId, m_appKey );
			HostSpec valenceHost = new HostSpec( "https", m_lmsUrl, 443 );
			ID2LUserContext userContext = appContext.CreateUserContext( m_userId, m_userKey, valenceHost );
			return new ValenceAuthenticator( userContext );
		}
	}
}
