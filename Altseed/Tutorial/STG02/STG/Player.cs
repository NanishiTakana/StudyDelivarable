using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    public class Player : CollidableObject
    {
        // ショットの効果音。
        private asd.SoundSource shotSound;

        // 破壊されたときの効果音。
        private asd.SoundSource deathSound;

        // ボムを発動した時の効果音。
        private asd.SoundSource bombSound;

        public Player()
        {
            // 画像を読み込み、プレイヤーのインスタンスに画像を設定する。
            Texture = asd.Engine.Graphics.CreateTexture2D("Player.png");
            // プレイヤーのインスタンスに画像の中心位置を設定する。
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            // プレイヤーの位置を変更する。
            Position = new asd.Vector2DF(320, 240);
            // ショットの効果音を読み込む。
            shotSound = asd.Engine.Sound.CreateSoundSource("Shot.wav", true);

            // 破壊されたときの効果音を読み込む。
            deathSound = asd.Engine.Sound.CreateSoundSource("Explode.wav", true);

            // ボムを発動したときの効果音を読み込む。
            bombSound = asd.Engine.Sound.CreateSoundSource("Bomb.wav", true);

            // プレイヤーの Radius は小さめにしておく
            Radius = Texture.Size.X / 8.0f;

        }



        protected override void OnUpdate()
        {
            foreach (var obj in Layer.Objects)
                CollideWith(obj as CollidableObject);

            // もし、上ボタンが押されていたら、位置に(0,-1)を足す。
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.ButtonState.Hold)
            {
                Position = Position + new asd.Vector2DF(0, -3);
            }
            // もし、下タンが押されていたら、位置に(0,-1)を足す。
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.ButtonState.Hold)
            {
                Position = Position + new asd.Vector2DF(0, 3);
            }
            // もし、右ボタンが押されていたら、位置に(0,-1)を足す。
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.ButtonState.Hold)
            {
                Position = Position + new asd.Vector2DF(3, 0);
            }
            // もし、左ボタンが押されていたら、位置に(0,-1)を足す。
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.ButtonState.Hold)
            {
                Position = Position + new asd.Vector2DF(-3, 0);
            }

            // もし、Zキーを押したら{}内の処理を行う。
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.ButtonState.Push)
            {
                Bullet bullet = new Bullet(Position + new asd.Vector2DF(0, -30), "PlayerBullet.png");
                // 弾のインスタンスをエンジンに追加する。
                Layer.AddObject(bullet);

                // ショットの効果音を再生する。
                asd.Engine.Sound.Play(shotSound);

            }

            //もしXキーが押されたら、大きい弾を発射する。
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.X) == asd.ButtonState.Push)
            {
                for (int i = 0; i < 24; i++)
                {
                    // ボムを生成
                    Bomb bomb = new Bomb(Position, 360 / 24 * i);

                    // ボム オブジェクトをエンジンに追加
                    asd.Engine.AddObject2D(bomb);
                }
                asd.Engine.Sound.Play(bombSound);

            }

            // プレイヤーの位置を取得する。
            asd.Vector2DF position = Position;

            // プレイヤーの位置を、(テクスチャの大きさ/2)～(ウインドウの大きさ-テクスチャの大きさ/2)の範囲に制限する。
            position.X = asd.MathHelper.Clamp(position.X, asd.Engine.WindowSize.X - Texture.Size.X / 2.0f, Texture.Size.X / 2.0f);

            position.Y = asd.MathHelper.Clamp(position.Y, asd.Engine.WindowSize.Y - Texture.Size.Y / 2.0f, Texture.Size.Y / 2.0f);

            // プレイヤーの位置を設定する。
            Position = position;



        }

        // 衝突時の動作
        public override void OnCollide(CollidableObject obj)
        {
            // このインスタンスと同じ位置にエフェクトインスタンスを生成して、エンジンに追加する。
            asd.Engine.AddObject2D(new BreakObjectEffect(Position));
            asd.Engine.Sound.Play(deathSound);
            // ゲームからオブジェクトを消滅させる
            Dispose();

        }

        // 自機の弾との当たり判定をコントロールするメソッド
        protected void CollideWith(CollidableObject obj)
        {
            // 当たり判定の相手が見つかってない場合はメソッドを終了
            if (obj == null)
                return;

            // obj が Bulletである場合にのみelse内を動作させる
            if (obj is EnemyBullet)
            {
                // obj が enemybullet であることを明示
                CollidableObject enemyBullet = obj;

                // bulletと衝突した場合には、衝突時処理を行う
                if (IsCollide(enemyBullet))
                {
                    OnCollide(enemyBullet);
                    enemyBullet.OnCollide(this);
                }
            }

        }

    }
}
