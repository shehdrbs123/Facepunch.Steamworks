using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	internal class ISteamVideo : BaseSteamInterface
	{
		public ISteamVideo( bool server = false ) : base( server )
		{
		}
		
		public override string InterfaceName => "STEAMVIDEO_INTERFACE_V002";
		
		public override void InitInternals()
		{
			GetVideoURLDelegatePointer = Marshal.GetDelegateForFunctionPointer<GetVideoURLDelegate>( Marshal.ReadIntPtr( VTable, 0) );
			IsBroadcastingDelegatePointer = Marshal.GetDelegateForFunctionPointer<IsBroadcastingDelegate>( Marshal.ReadIntPtr( VTable, 8) );
			GetOPFSettingsDelegatePointer = Marshal.GetDelegateForFunctionPointer<GetOPFSettingsDelegate>( Marshal.ReadIntPtr( VTable, 16) );
			GetOPFStringForAppDelegatePointer = Marshal.GetDelegateForFunctionPointer<GetOPFStringForAppDelegate>( Marshal.ReadIntPtr( VTable, 24) );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate void GetVideoURLDelegate( IntPtr self, AppId_t unVideoAppID );
		private GetVideoURLDelegate GetVideoURLDelegatePointer;
		
		#endregion
		internal void GetVideoURL( AppId_t unVideoAppID )
		{
			GetVideoURLDelegatePointer( Self, unVideoAppID );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool IsBroadcastingDelegate( IntPtr self, ref int pnNumViewers );
		private IsBroadcastingDelegate IsBroadcastingDelegatePointer;
		
		#endregion
		internal bool IsBroadcasting( ref int pnNumViewers )
		{
			return IsBroadcastingDelegatePointer( Self, ref pnNumViewers );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate void GetOPFSettingsDelegate( IntPtr self, AppId_t unVideoAppID );
		private GetOPFSettingsDelegate GetOPFSettingsDelegatePointer;
		
		#endregion
		internal void GetOPFSettings( AppId_t unVideoAppID )
		{
			GetOPFSettingsDelegatePointer( Self, unVideoAppID );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool GetOPFStringForAppDelegate( IntPtr self, AppId_t unVideoAppID, StringBuilder pchBuffer, ref int pnBufferSize );
		private GetOPFStringForAppDelegate GetOPFStringForAppDelegatePointer;
		
		#endregion
		internal bool GetOPFStringForApp( AppId_t unVideoAppID, StringBuilder pchBuffer, ref int pnBufferSize )
		{
			return GetOPFStringForAppDelegatePointer( Self, unVideoAppID, pchBuffer, ref pnBufferSize );
		}
		
	}
}