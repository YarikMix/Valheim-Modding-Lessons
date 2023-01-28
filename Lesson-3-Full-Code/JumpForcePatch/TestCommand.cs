using Jotunn.Entities;
using Jotunn.Managers;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JumpForcePatch
{
    class TestCommand : ConsoleCommand
    {
        public override string Name
        {
            get
            {
                return "testcommand";
            }
        }

        public override string Help
        {
            get
            {
                return "sadadsf";
            }
        }

        public override void Run(string[] args)
        {
            var position = Player.m_localPlayer.transform.position + 5f * Vector3.forward;
            GameObject gameObject = Object.Instantiate(PrefabManager.Instance.GetPrefab("Boar"), position, Quaternion.identity);

            int lvl = 1;

            if (args.Length > 0)
            {
                lvl = Convert.ToInt32(args[0]);
            }
            Character character = gameObject.GetComponent<Character>();
            character.SetLevel(lvl);

            Tameable tameable = gameObject.GetComponent<Tameable>();
            tameable.Tame();
        }
    }
}
