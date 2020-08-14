using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    public class Boss : Enemy
    {

        // 乱数生成に使うために宣言
        private Random rand = new Random();
        // ボスの速度の宣言
        private asd.Vector2DF moveVelocity;

        // HP関連の宣言
        // maxHPは定数として代入しておく
        private const int maxHP = 1000;
        private int HP;
        private int HPlength;
        private asd.Color red = new asd.Color(255, 0, 0, 255);
        private asd.Vector2DF startHPLine;
        private asd.Vector2DF destHPLine;
        private const int diameterHPLine = 20;

        //Laserのインスタンスの情報をBossが持つようにする
        private Laser laserRef;



        public Boss(asd.Vector2DF pos, Player player)
            : base(pos, player)
        {
            // base(pos, player) のところで、Enemyクラスのコンストラクタは実行されています

            // Boss のテクスチャを上書きする
            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/Boss.png");

            // CenterPositionを上書きする
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            // HPを設定する
            HP = maxHP;

            // 当たり判定の半径を上書きする
            Radius = Texture.Size.X / 2;

        }

        protected override void OnUpdate()
        {
            // HPの表示

            // 表示するHPゲージの長さを計算する
            HPlength = (asd.Engine.WindowSize.X - 10) * HP / maxHP;

            // HPゲージの左端を設定する
            startHPLine = new asd.Vector2DF(5, 15);

            // HPゲージの右端を計算する
            destHPLine = startHPLine + new asd.Vector2DF(HPlength, 0);

            // HPゲージを描画する
            DrawLineAdditionally(startHPLine, destHPLine, red, diameterHPLine, asd.AlphaBlendMode.Blend, 30);

            // ボスの位置を更新
            Position += moveVelocity;

            // 一定の間隔で速度を更新する
            if (count % 60 == 0)
            {
                //ここで行う処理は、UpdateRandVelocity に移動させる。
                UpdateRandVelocity();
                //BossAroundShot();
                BossLaser();
                BossVortexShot(count * 7);
                
            }
            // ボスが画面外に出た場合に、速度を更新する
            else if (Position.Y < Texture.Size.Y / 2.0f
                || Position.Y > asd.Engine.WindowSize.Y - Texture.Size.Y / 2.0f
                || Position.X < Texture.Size.X / 2.0f
                || Position.X > asd.Engine.WindowSize.X - Texture.Size.X / 2.0f)
            {
                UpdateRandVelocity();
            }


            // カウンタの増加機能を使いまわすため基底(Enemy)クラスのOnUpdateを呼び出す。
            base.OnUpdate();



        }
        public override void OnCollide(CollidableObject obj)
        {
            // どんなプレイヤーの弾でも当たればHPが50減る
            HP -= 50;
        }

        // UpdateRandVelocityを定義する
        private void UpdateRandVelocity()
        {
            // 目標点が画面上半分になるように (x, y)の上限を設定する
            asd.Vector2DF limitSize = new asd.Vector2DF(asd.Engine.WindowSize.X, asd.Engine.WindowSize.Y / 2.0f);

            // (0, 0)から上限のlimitSizeまでの範囲で乱数を生成して、目標座標を設定する
            asd.Vector2DF destPos = new asd.Vector2DF(rand.Next() % limitSize.X, rand.Next() % limitSize.Y);

            // 目的座標への速度の向きを設定し、単位ベクトルとする
            moveVelocity = (destPos - Position).Normal;
        }

        private void BossAroundShot()
        {
            // 砲台の位置を設定する
            asd.Vector2DF cannon1Pos = Position + new asd.Vector2DF(-Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            asd.Vector2DF cannon2Pos = Position + new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);

            // 5方向に弾が出るようにする（偶数の場合、場合分けが必要ですが今回は省略しています）
            int nWay = 5;

            // 方向ベクトルを宣言する
            asd.Vector2DF dirVector = new asd.Vector2DF(1, 0);

            //  方向ベクトルの大きさを3とする
            dirVector.Length = 2.0f;

            // 砲台1からプレイヤーに向く角度を設定する
            float degree = (player.Position - cannon1Pos).Degree;

            // nWayの数だけループする(iが0の時がちょうど真ん中にくるように)
            for (int i = -nWay / 2; i <= nWay / 2; i++)
            {
                // 発射角度を i*10 だけずらす
                dirVector.Degree = degree + i * 10;

                // 砲台1からの弾をレイヤーに登録する
                Layer.AddObject(new StraightMovingEnemyBullet(cannon1Pos, dirVector));
            }

            // 砲台2からプレイヤーに向く角度を設定する
            degree = (player.Position - cannon2Pos).Degree;

            // nWayの数だけループする(iが0の時がちょうど真ん中にくるように)
            for (int i = -nWay / 2; i <= nWay / 2; i++)
            {
                // 発射角度を i*10 だけずらす
                dirVector.Degree = degree + i * 10;

                // 砲台2からの弾をレイヤーに登録する
                Layer.AddObject(new StraightMovingEnemyBullet(cannon2Pos, dirVector));
            }



            // 2つの弾を中心から発射する

            // ボスの中心からプレーヤーに向く角度を設定する
            degree = (player.Position - Position).Degree;

            // 一定の角度ずらす
            dirVector.Degree = degree - 8;

            // 弾をレイヤーに登録
            Layer.AddObject(new StraightMovingEnemyBullet(Position, dirVector));

            // 一定の角度ずらす
            dirVector.Degree = degree + 8;

            // 弾をレイヤーに登録
            Layer.AddObject(new StraightMovingEnemyBullet(Position, dirVector));

        }

        private void BossLaser()
        {
            // LaserをBossが制御できるように、Laserのインスタンスの情報をBossが持つようにする
            var laserRef = new Laser(player, this);

            // Laserをレイヤーに登録する
            Layer.AddObject(laserRef);
        }

        private void BossVortexShot(float degree)
        {
            // 砲台の位置を設定する
            asd.Vector2DF cannon3Pos = Position + new asd.Vector2DF(Texture.Size.X / 2.0f, -Texture.Size.Y / 2.0f);
            asd.Vector2DF cannon4Pos = Position + new asd.Vector2DF(-Texture.Size.X / 2.0f, -Texture.Size.Y / 2.0f);

            // 方向ベクトルを宣言する
            asd.Vector2DF dirVector = new asd.Vector2DF(1, 0);

            // 方向ベクトルの大きさを3とする
            dirVector.Length = 3.0f;

            // 方向ベクトルの向きをdegreeに合わせる
            // degreeが0度だと90度（下向き）を指すようにする
            dirVector.Degree = degree + 90;

            // 弾をレイヤーに登録する
            Layer.AddObject(new StraightMovingEnemyBullet(cannon3Pos, dirVector));

            // 方向ベクトルの向きを-degreeに合わせる
            // 左右対称になるように、degreeが0度だと90度（下向き）を指すようにする
            dirVector.Degree = -degree + 90;

            // 弾をレイヤーに登録する
            Layer.AddObject(new StraightMovingEnemyBullet(cannon4Pos, dirVector));
        }


    }
}