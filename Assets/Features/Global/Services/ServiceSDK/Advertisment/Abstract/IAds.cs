using Cysharp.Threading.Tasks;

namespace Global.Services.ServiceSDK.Advertisment.Runtime
{
    public interface IAds
    {
        void ShowInterstitial();
        UniTask<RewardAdResult> ShowRewarded();
    }
}