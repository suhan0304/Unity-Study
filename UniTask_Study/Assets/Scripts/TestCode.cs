using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TestCode : MonoBehaviour
{   
    private const string AppleImagePath = "https://cdn.tridge.com/attachment-file/8d/e0/d9/8de0d913f1bd9438ce1ab69086961e2c884877bd/apple.jpeg";
    public RawImage profileImage;

    private IEnumerator WaitGetWebTexture(UnityAction<Texture2D> action) {
        // 코루틴은 IEnumrator 형이기 때문에 가져온 Texture를 반환 할 수는 없다.
        // => Action을 추가로 달아주어야 한다.

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(AppleImagePath);
        yield return request.SendWebRequest();

        // Connection or Protocol Error가 발생한 경우
        if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError) {
            // Error 처리
            Debug.LogError(request.error);
        }
        else {
            // Reqeust 성공
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            action.Invoke(texture);
        }
    }

    private void Start() {
        StartCoroutine(WaitGetWebTexture(texture => {
            profileImage.texture = texture;
        }));
    }
}
