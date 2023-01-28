namespace JumpForcePatch
{
    class SE_TestStatusEffect : SE_Stats
    {
        public SE_TestStatusEffect()
        {
            name = "SE_TestStatusEffect";
            m_name = "Статусный эффект";
            // m_icon = PrefabManager.Instance.GetPrefab("Wood").GetComponent<ItemDrop>().m_itemData.GetIcon();
            // m_icon = AssetUtils.LoadSpriteFromFile("JumpForcePatch/Assets/Cat.png");
            m_icon = Helpers.CreateSprite("Cat.png");
        }

        public override void ModifyMaxCarryWeight(float baseLimit, ref float limit)
        {
            limit = 1000;
            base.ModifyMaxCarryWeight(baseLimit, ref limit);
        }

        public float timer;
        public float messageInterval = 5f;

        public override void UpdateStatusEffect(float dt)
        {
            timer -= dt;
            if (timer < 0)
            {
                Player.m_localPlayer.Message(MessageHud.MessageType.Center, "Просто привет, просто как дела");

                timer = messageInterval;
            }
        }
    }
}
