﻿using System.Linq;
using TowerDefense.Source.Attacks;

namespace TowerDefense.Source.Guardians.Wizards
{
    public class IceWizard : Guardian
    {
        public sealed override IAttack AttackType { get; protected set; }
        public sealed override int ChargeAttackCost { get; protected set; }
        public sealed override bool ChargeAttackEnabled { get; protected set; }
        public sealed override double ChargeAttackTimer { get; protected set; }
        public sealed override int PromoteCost { get; protected set; }
        public sealed override int PromoteLevel { get; protected set; }
        public sealed override int UpgradeCost { get; protected set; }

        public IceWizard()
        {
            // TODO: implement MageBall and others
            //AttackType = new SingleArrow(AttackSpeedBase.SingleMageBall, new MageBall(ProjectileDamageBase.MageBall, ProjectileSpeedBase.MageBall));
            ChargeAttackCost = Constants.ChargeAttackCostBase.IceWizard;
            ChargeAttackEnabled = false;
            ChargeAttackTimer = Constants.ChargeAttackTimerBase.IceWizard;
            PromoteCost = Constants.GuardianPromoteCostBase.IceWizard;
            PromoteLevel = Constants.GuardianPromotionLevels.IceWizard.First();
            UpgradeCost = Constants.GuardianUpgradeCostBase.IceWizard;

            Upgrade();
        }

        public sealed override void ActivateChargeAttack()
        {
            // TODO: implement
        }

        public sealed override void Promote()
        {
            // TODO: implement
        }

        public override void Demote(IAttack oldAttackType, int oldPromoteLevel) { }

        public sealed override void Upgrade()
        {
            ++Level;
            UpgradeCost = (int)(UpgradeCost * Constants.GuardianUpgradeCostMultiplier.IceWizard);
            AttackType.Upgrade();
        }

        public override void Downgrade(IAttack oldAttackType, int oldUpgradeCost) { }
    }
}
