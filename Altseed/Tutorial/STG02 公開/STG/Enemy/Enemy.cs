using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    public class Enemy : CollidableObject
    {
        // 毎フレーム1増加し続けるカウンタ変数（継承先のクラスで使いまわすため、protectedに設定する。）
        protected int count;

        // プレイヤーへの参照（継承先のクラスで使いまわすため、protectedに設定する。）
        protected Player player;

        // ショットの効果音。継承先のクラスでも再生できるようにprotectedに設定する。
        protected asd.SoundSource shotSound;

        // 破壊されるときの効果音。
        private asd.SoundSource deathSound;

        // コンストラクタ(敵の初期位置を引数として受け取る。)
        public Enemy(asd.Vector2DF pos, Player player)
            : base()
        {
            // 敵のインスタンスの位置を設定する。
            Position = pos;

            //　画像を読み込み、敵のインスタンスに画像を設定する。
            Texture = asd.Engine.Graphics.CreateTexture2D("Enemy.png");

            // 敵のインスタンスに画像の中心位置を設定する。
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);

            // 画像の半分の大きさを Radius とする
            Radius = Texture.Size.X / 2.0f;


            // カウンタ変数を0に初期化する。
            count = 0;

            // Playerクラスへの参照を保持する。
            this.player = player;

            // ショットの効果音を読み込む。
            shotSound = asd.Engine.Sound.CreateSoundSource("Shot2.wav", true);

            // 破壊されるときの効果音を読み込む。
            deathSound = asd.Engine.Sound.CreateSoundSource("Explode.wav", true);

        }

        protected override void OnUpdate()
        {
            // 当たり判定を処理する
            foreach (var obj in Layer.Objects)
                CollideWith((obj as CollidableObject));
            ++count;

        }

        // 画面外に出た時に削除する関数。
        protected void DisposeFromGame()
        {
            // 画面外に出たら
            var windowSize = asd.Engine.WindowSize;
            if (Position.Y < -Texture.Size.Y || Position.Y > windowSize.Y + Texture.Size.Y || Position.X < -Texture.Size.X || Position.X > windowSize.X + Texture.Size.X)
            {
                // 削除する。
                Dispose();
            }
        }

        protected void VortexShot(float degree)
        {
            asd.Vector2DF dirVector = new asd.Vector2DF(1, 0);
            dirVector.Degree = degree;
            Layer.AddObject(new StraightMovingEnemyBullet(Position, dirVector));

            asd.Engine.Sound.Play(shotSound);
        }


        // 衝突時の動作(子クラスでoverrideが可能)
        public override void OnCollide(CollidableObject obj)
        {
            // このインスタンスと同じ位置にエフェクトインスタンスを生成して、エンジンに追加する。
            Layer.AddObject(new BreakObjectEffect(Position));

            asd.Engine.Sound.Play(deathSound);
            // ゲームからオブジェクトを消滅させる
            Dispose();

            // スコアを加算
            var scene = (GameScene)Layer.Scene;
            scene.Score += 1;

        }

        // 自機の弾との当たり判定をコントロールするメソッド
        protected void CollideWith(CollidableObject obj)
        {
            // 当たり判定の相手が見つかってない場合はメソッドを終了
            if (obj == null)
                return;

            // obj が Bulletである場合にのみelse内を動作させる
            if (obj is Bullet)
            {
                // obj が bullet であることを明示
                CollidableObject bullet = obj;

                // bulletと衝突した場合には、衝突時処理を行う
                if (IsCollide(bullet))
                {
                    OnCollide(bullet);
                    bullet.OnCollide(this);
                }
            }
        }


    }
}