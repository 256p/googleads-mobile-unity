// Copyright (C) 2020 Google LLC.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;


public class DummyAdBehaviour : MonoBehaviour
{

    public void SetAndStretchAd(GameObject dummyAd, AdPosition pos)
    {
        if (dummyAd != null) {
            Image myImage = dummyAd.GetComponentInChildren<Image>();
            RectTransform rect = myImage.GetComponent<RectTransform>();

            rect.pivot = new Vector2(0.5f, 0.5f);

            if (pos == AdPosition.Bottom || pos == AdPosition.BottomLeft || pos == AdPosition.BottomRight)
            {
                rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, rect.sizeDelta.y);
                rect.anchoredPosition = new Vector2(0, (float)rect.sizeDelta.y/2);
            } else if (pos == AdPosition.Top || pos == AdPosition.TopLeft || pos == AdPosition.TopRight)
            {
                rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rect.sizeDelta.y);
                rect.anchoredPosition = new Vector2(0, -(float)rect.sizeDelta.y/2);
            } else if (pos == AdPosition.Center)
            {
                rect.anchoredPosition = new Vector2(0, 0);
            } else
            {
                rect.anchoredPosition = rect.position;
            }
        } else {
            Debug.Log("Invalid Dummy Ad");
        }
    }

    public void AnchorAd(GameObject dummyAd, AdPosition position)
    {
        if (dummyAd != null) {
            Image myImage = dummyAd.GetComponentInChildren<Image>();
            RectTransform rect = myImage.GetComponent<RectTransform>();

            float x = (float)rect.sizeDelta.x/2;
            float y = (float)rect.sizeDelta.y/2;
        
            
            switch (position)
            {
                case (AdPosition.TopLeft):
                    rect.pivot = new Vector2(0.5f, 0.5f);
                    rect.anchorMin = new Vector2(0, 1);
                    rect.anchorMax = new Vector2(0, 1);
                    rect.anchoredPosition = new Vector2(x, -y);
                    break;
                case (AdPosition.TopRight):
                    rect.pivot = new Vector2(0.5f, 0.5f);
                    rect.anchorMin = new Vector2(1, 1);
                    rect.anchorMax = new Vector2(1, 1);
                    rect.anchoredPosition = new Vector2(-x, -y);
                    break;
                case (AdPosition.Top):
                    rect.pivot = new Vector2(0.5f, 0.5f);
                    rect.anchorMin = new Vector2(0.5f, 1);
                    rect.anchorMax = new Vector2(0.5f, 1);
                    rect.anchoredPosition = new Vector2(0, -y);
                    break;
                case (AdPosition.Bottom):
                    rect.pivot = new Vector2(0.5f, 0.5f);
                    rect.anchorMin = new Vector2(0.5f, 0);
                    rect.anchorMax = new Vector2(0.5f, 0);
                    rect.anchoredPosition = new Vector2(0, y);
                    break;
                case (AdPosition.BottomRight):
                    rect.pivot = new Vector2(0.5f, 0.5f);
                    rect.anchorMin = new Vector2(1, 0);
                    rect.anchorMax = new Vector2(1, 0);
                    rect.anchoredPosition = new Vector2(-x, y);
                    break;
                case (AdPosition.BottomLeft):
                    rect.pivot = new Vector2(0.5f, 0.5f);
                    rect.anchorMin = new Vector2(0, 0);
                    rect.anchorMax = new Vector2(0, 0);
                    rect.anchoredPosition = new Vector2(x, y);
                    break;
                default:
                    rect.pivot = new Vector2(0.5f, 0.5f);
                    rect.anchorMin = new Vector2(0.5f, 0.5f);
                    rect.anchorMax = new Vector2(0.5f, 0.5f);
                    rect.anchoredPosition = new Vector2(0, 0);
                    break;
            }
        } else {
            Debug.Log("Invalid Dummy Ad");
        }
    }

    public ButtonBehaviour GetButtonBehaviour(GameObject dummyAd)
    {
        return dummyAd.GetComponentInChildren<ButtonBehaviour>();
    }

    public GameObject ShowAd(GameObject dummyAd, Vector3 position)
    { 
        return Instantiate(dummyAd, position, Quaternion.identity) as GameObject;
    }

    public void DestroyAd(GameObject dummyAd)
    {
       if (dummyAd != null) {
            Destroy(dummyAd);
       } else {
           Debug.Log("Invalid Dummy Ad");
       }
    }
}
