using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonTidesAP.Helpers;

public static class GearOrderHelper
{
    private static int GearIndex = 0;
    private static string[] GearIDs =
    {
        "b8182536-acf0-456c-b61b-4c2d8c825968",
        "1d8f69a7-94eb-4ec1-8be7-12c9e7b5daa4",
        "17f6edf5-7dd5-4ae4-94a4-4bf8fc1f04ba",
        "d238061e-7778-40b6-b983-2ddd6d15edf2",
        "efa20536-dd8f-43c2-9dbc-29e0f623a0f6",
        "8bc92076-20c7-445e-8883-83ff0e2dfc24",
        "ebb563f7-b810-4a98-adb5-d3b548c83758",
        "21d1cb9e-8dae-49bb-bd34-c829d7c4a9c6",
        "2700e2dc-3630-4d3c-a06b-84879328fe79",
        "b6a38925-4d67-4c93-b644-d14bd6102fb0",
        "c4b2b435-a241-4058-99f5-36e91e40956e",
        "ee9af3c2-b8e1-4d38-a372-36323995f6a7",
        "2b1c40ee-17e8-475b-aa16-1445ba39e644",
        "8c8f4612-a043-4623-994f-a0f0f44d6bbb",
        "771d1538-3e0a-41d5-b6e9-d77babee52bd",
        "54ed1036-b146-4561-a8a6-c087dd8fddcb",
        "44bbb89a-64e2-43a9-8a97-d9320d8b8e52",
        "14fd0074-cf85-4a2c-86fd-c0790a1a8877",
        "0c07a885-c6b2-47ed-91be-9005907e7135",
        "d04d0ecf-6e07-401e-b714-a11cd956e7a0",
        "334aa1ad-a7bf-427d-aad5-c9b5a6851816",
        "0822f429-0f7b-4acf-99f9-0d251d6b0821",
        "4777bcc4-4bc4-483a-8d4d-a568a38208b8",
        "f9fdf19e-a85d-4c2b-9725-c07551fc3774",
        "556088bb-1906-4d31-bd86-768552d1280e",
        "d124515a-f33a-4be4-a75d-51c703057f47",
        "2b8348a7-d1e0-48db-aea1-cee536c368e1",
        "13c9705e-3b34-40f8-bc03-f208a48269d9",
        "78e9fcef-8312-4886-a9e5-ffbef48124a5",
        "348e0f78-6b6d-497c-9013-ed2e6500ec9d",
        "9691e282-09e6-4c08-98fe-deeb515ea19d",
        "ca56ad4d-aabf-425c-b55d-9f7b678f3cfa",
        "53021f1e-1d8d-4367-a826-3a460eb4c259",
        "fb45cdad-d0fa-47ef-9911-42ba762431ad",
        "7d363363-b59d-495f-baff-bbd189e94560",
        "44783850-0201-4bc6-966a-395e5eba92fe",
        "c002e50a-9516-4365-aa4d-ec474c305ab8",
        "7c666c19-0679-42fe-86a1-aa8caac1cee1",
        "ab58ad9c-98ba-4f53-856a-7cae08b7f2b8",
        "0049b9d1-12ae-4412-8f80-066e7092f1d8",
        "5e8bc06f-7d90-422e-8ab0-3e6477aaaa02",
        "c1485ac7-3038-437d-934e-e584e0f3e944",
        "8da23e11-c76c-4765-8c42-3e6ae146d520",
        "75ad5adc-7a13-4304-9e6b-02d9898cac0b",
    };

    public static string GetGearID()
    {
        string val = GearIDs[GearIndex];
        GearIndex++;
        return val;
    }

}
