using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;
using Il2CppTMPro;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;

namespace DemonTidesAP
{
    [RegisterTypeInIl2Cpp]
    public class ConnectMenu : MonoBehaviour
    {
        public static ConnectMenu Instance { get; private set; }

        public static Color TextAccent => new Color(1, 0.686f, 0);

        public TextMeshProUGUI titleText;
        public TextMeshProUGUI addressLabel;
        public TMP_InputField addressInput;
        public TextMeshProUGUI nameLabel;
        public TMP_InputField nameInput;
        public TextMeshProUGUI passwordLabel;
        public TMP_InputField passwordInput;
        public FzButton connectButton;

        public TextMeshProUGUI resultText;
        public float timer = 0f;

        public bool IsAnyInputFocused => addressInput.isFocused || nameInput.isFocused || passwordInput.isFocused;
        private bool previousInputFocused = false;

        public List<GameObject> uiPromptObjects = new List<GameObject>();
        public CanvasGroup uiPromptGroup;

        public static void Setup()
        {
            if (Instance != null) return;

            TMP_FontAsset inputFont = Core.assetBundle.LoadAsset<TMP_FontAsset>("assets/rubik-regular sdf.asset");

            TitleMenu titleMenu = Component.FindFirstObjectByType<TitleMenu>(FindObjectsInactive.Include);
            Transform uiTitle = titleMenu.transform.Find("UI Prompt Legend TITLE");
            Transform uiContent = uiTitle.Find("Content");

            GameObject window = GameObject.Instantiate(Core.notificationUI.transform.Find("Window").gameObject);
            GameObject.DontDestroyOnLoad(window);
            window.transform.SetParent(uiTitle);
            window.transform.localPosition = new Vector3(0, 250, 0);
            window.transform.localScale = Vector3.one;

            RectTransform bg = window.transform.Find("BG").GetComponent<RectTransform>();
            bg.sizeDelta = new Vector2(425, 250);
            bg.localPosition = new Vector3(0, -75, 0);
            bg.Find("BG Color").transform.localPosition = new Vector3(0, 100, 0);

            Instance = window.AddComponent<ConnectMenu>();
            Instance.titleText = window.transform.Find("Banner Text/Text").GetComponent<TextMeshProUGUI>();
            Instance.titleText.text = "Archipelago";

            Instance.resultText = GameObject.Instantiate(Instance.titleText.gameObject, window.transform).GetComponent<TextMeshProUGUI>();
            Instance.resultText.transform.localPosition = new Vector3(0, 100, 0);
            Instance.resultText.name = "Result";
            Instance.resultText.text = "?";
            Instance.resultText.enableAutoSizing = false;
            Instance.resultText.alignment = TextAlignmentOptions.Bottom;
            Instance.resultText.enableWordWrapping = false;
            Instance.resultText.fontSize = 30;
            Instance.resultText.gameObject.SetActive(false);

            for (int i = 0; i < uiContent.childCount; i++)
            {
                Instance.uiPromptObjects.Add(uiContent.GetChild(i).gameObject);
            }
            Instance.uiPromptGroup = uiContent.gameObject.AddComponent<CanvasGroup>();

            window.transform.Find("Banner Text/Icon").GetComponent<Image>().sprite = Core.assetBundle.LoadAsset<Sprite>("assets/archipelago_outline.png");

            GameObject info = window.transform.Find("Info Text").gameObject;
            info.transform.localPosition = new Vector3(0, -25, 0);

            GameObject addressParent = new GameObject() { name = "Address" };
            addressParent.transform.SetParent(info.transform);

            GameObject addressLabelObj = info.transform.Find("Text").gameObject;
            addressLabelObj.name = "Label";
            addressLabelObj.transform.SetParent(addressParent.transform);
            Instance.addressLabel = addressLabelObj.GetComponent<TextMeshProUGUI>();
            Instance.addressLabel.text = "Address:";
            Instance.addressLabel.color = TextAccent;
            Instance.addressLabel.alignment = TextAlignmentOptions.Left;

            GameObject addressInputObj = GameObject.Instantiate(addressLabelObj, addressParent.transform);
            addressInputObj.name = "Input";
            Instance.addressInput = addressInputObj.AddComponent<TMP_InputField>();
            Instance.addressInput.textComponent = addressInputObj.GetComponent<TextMeshProUGUI>();
            Instance.addressInput.textComponent.fontStyle = FontStyles.Underline;
            Instance.addressInput.textComponent.alignment = TextAlignmentOptions.Left;
            Instance.addressInput.textComponent.color = Color.black;
            Instance.addressInput.textComponent.font = inputFont;
            Instance.addressInput.resetOnDeActivation = false;
            Instance.addressInput.text = "archipelago.gg";
            Vector3 addressPos = new Vector3(1455, Instance.addressInput.transform.localPosition.y + 3, Instance.addressInput.transform.localPosition.z);
            Instance.addressInput.transform.localPosition = addressPos;
            Instance.addressInput.textComponent.transform.localPosition = addressPos;

            GameObject nameParent = GameObject.Instantiate(addressParent, info.transform);
            nameParent.name = "Name";
            nameParent.transform.Translate(0, -35, 0);
            Instance.nameLabel = nameParent.transform.Find("Label").GetComponent<TextMeshProUGUI>();
            Instance.nameLabel.text = "Name:";
            Instance.nameInput = nameParent.transform.Find("Input").GetComponent<TMP_InputField>();
            Instance.nameInput.text = "Beebz";
            Vector3 namePos = new Vector3(1395, Instance.nameInput.transform.localPosition.y + 2, Instance.nameInput.transform.localPosition.z);
            Instance.nameInput.transform.localPosition = namePos;
            Instance.nameInput.textComponent.transform.localPosition = namePos;

            GameObject passwordParent = GameObject.Instantiate(addressParent, info.transform);
            passwordParent.name = "Password";
            passwordParent.transform.Translate(0, -70, 0);
            Instance.passwordLabel = passwordParent.transform.Find("Label").GetComponent<TextMeshProUGUI>();
            Instance.passwordLabel.text = "Password:";
            Instance.passwordInput = passwordParent.transform.Find("Input").GetComponent<TMP_InputField>();
            Instance.passwordInput.text = "";
            Vector3 passwordPos = new Vector3(1485, Instance.passwordInput.transform.localPosition.y + 1, Instance.passwordInput.transform.localPosition.z);
            Instance.passwordInput.transform.localPosition = passwordPos;
            Instance.passwordInput.textComponent.transform.localPosition = passwordPos;

            AsyncOperationHandle<GameObject> handle = Addressables.LoadAsset<GameObject>("Assets/UI/Prefabs/General/General Buttons/UI Large Button.prefab");
            handle.WaitForCompletion();
            GameObject button = GameObject.Instantiate(handle.Result, window.transform);
            button.transform.localPosition = new Vector3(0, -150, 0);
            button.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            button.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Connect";
            Instance.connectButton = button.GetComponent<FzButton>();
            Instance.connectButton.GetComponent<UIFeedbackBounce>().originalPosition = new Vector3(0, -150, 0);

            Instance.connectButton.onClick.AddListener((Action)Instance.Connect);
        }

        public void OnEnable()
        {
            MelonCoroutines.Start(DelayUpdate());
        }

        public void Update()
        {
            if (!Core.Connected && previousInputFocused != IsAnyInputFocused)
            {
                previousInputFocused = IsAnyInputFocused;
                SetUIPromptsActive(!IsAnyInputFocused);
            }

            if (timer > 0f)
            {
                Color color = Color.Lerp(new Color(TextAccent.r, TextAccent.g, TextAccent.b, 0), TextAccent, timer);
                resultText.color = color;

                timer -= Time.deltaTime;
            }
            else if (timer < 0f) timer = 0f;
        }

        public IEnumerator DelayUpdate()
        {
            yield return null;

            this.transform.localPosition = new Vector3(0, 250, 0);

            int padX = 8;
            int padY = 1;

            Vector3 addressPos = new Vector3(addressLabel.transform.localPosition.x + addressLabel.renderedWidth + padX, addressLabel.transform.localPosition.y + padY, 0);
            addressInput.transform.localPosition = addressPos;

            Vector3 namePos = new Vector3(nameLabel.transform.localPosition.x + nameLabel.renderedWidth + padX, nameLabel.transform.localPosition.y + padY, 0);
            nameInput.transform.localPosition = namePos;

            Vector3 passwordPos = new Vector3(passwordLabel.transform.localPosition.x + passwordLabel.renderedWidth + padX, passwordLabel.transform.localPosition.y + padY, 0);
            passwordInput.transform.localPosition = passwordPos;

            foreach (TMP_InputField input in GetComponentsInChildren<TMP_InputField>(true))
            {
                if (input.caretRectTrans == null) input.OnEnable();
                else input.caretRectTrans.localPosition = input.transform.localPosition;
            }
        }

        public void SetResult(string result)
        {
            if (result == null || result.IsWhiteSpace())
            {
                resultText.gameObject.SetActive(false);
            }
            else
            {
                resultText.text = result;
                timer = 6f;
                resultText.gameObject.SetActive(true);
            }
        }

        public void SetInputsInteractable(bool active)
        {
            addressInput.interactable = active;
            nameInput.interactable = active;
            passwordInput.interactable = active;
            connectButton.interactable = active;
        }

        public void SetUIPromptsActive(bool active)
        {
            //Core.Logger.Msg($"Set UI prompts: {active}");

            if (active) uiPromptGroup.alpha = 1;
            else
            {
                uiPromptGroup.alpha = 0.3f;
                addressInput.caretRectTrans.gameObject.SetActive(true);
                nameInput.caretRectTrans.gameObject.SetActive(true);
                passwordInput.caretRectTrans.gameObject.SetActive(true);
            }

            foreach (GameObject gameObject in uiPromptObjects)
            {
                gameObject.GetComponent<FzButton>().enabled = active;
                gameObject.GetComponent<MenuInputListener>().enabled = active;
            }
        }

        public void Connect()
        {
            addressInput.caretRectTrans.gameObject.SetActive(false);
            nameInput.caretRectTrans.gameObject.SetActive(false);
            passwordInput.caretRectTrans.gameObject.SetActive(false);

            Core.APConnect(addressInput.text, nameInput.text, passwordInput.text);
        }
    }
}
