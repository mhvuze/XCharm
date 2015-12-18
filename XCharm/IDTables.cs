﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCharm
{
    class IDTables
    {
        public static Dictionary<int, string> skl_tbl = new Dictionary<int, string>();
        public static Dictionary<int, string> type_tbl = new Dictionary<int, string>();

        public static void FillTables()
        {
            skl_tbl.Add(0, "なし");
            skl_tbl.Add(1, "毒");
            skl_tbl.Add(2, "麻痺");
            skl_tbl.Add(3, "睡眠");
            skl_tbl.Add(4, "気絶");
            skl_tbl.Add(5, "聴覚保護");
            skl_tbl.Add(6, "風圧");
            skl_tbl.Add(7, "耐震");
            skl_tbl.Add(8, "だるま");
            skl_tbl.Add(9, "耐暑");
            skl_tbl.Add(10, "耐寒");
            skl_tbl.Add(11, "寒冷適応");
            skl_tbl.Add(12, "炎熱適応");
            skl_tbl.Add(13, "盗み無効");
            skl_tbl.Add(14, "対防御DOWN");
            skl_tbl.Add(15, "狂撃耐性");
            skl_tbl.Add(16, "細菌学");
            skl_tbl.Add(17, "裂傷");
            skl_tbl.Add(18, "攻撃");
            skl_tbl.Add(19, "防御");
            skl_tbl.Add(20, "体力");
            skl_tbl.Add(21, "火耐性");
            skl_tbl.Add(22, "水耐性");
            skl_tbl.Add(23, "雷耐性");
            skl_tbl.Add(24, "氷耐性");
            skl_tbl.Add(25, "龍耐性");
            skl_tbl.Add(26, "属性耐性");
            skl_tbl.Add(27, "火属性攻撃");
            skl_tbl.Add(28, "水属性攻撃");
            skl_tbl.Add(29, "雷属性攻撃");
            skl_tbl.Add(30, "氷属性攻撃");
            skl_tbl.Add(31, "龍属性攻撃");
            skl_tbl.Add(32, "属性攻撃");
            skl_tbl.Add(33, "特殊攻撃");
            skl_tbl.Add(34, "研ぎ師");
            skl_tbl.Add(35, "匠");
            skl_tbl.Add(36, "斬れ味");
            skl_tbl.Add(37, "剣術");
            skl_tbl.Add(38, "研磨術");
            skl_tbl.Add(39, "鈍器");
            skl_tbl.Add(40, "抜刀会心");
            skl_tbl.Add(41, "抜刀減気");
            skl_tbl.Add(42, "納刀");
            skl_tbl.Add(43, "装填速度");
            skl_tbl.Add(44, "反動");
            skl_tbl.Add(45, "精密射撃");
            skl_tbl.Add(46, "通常弾強化");
            skl_tbl.Add(47, "貫通弾強化");
            skl_tbl.Add(48, "散弾強化");
            skl_tbl.Add(49, "重撃弾強化");
            skl_tbl.Add(50, "通常弾追加");
            skl_tbl.Add(51, "貫通弾追加");
            skl_tbl.Add(52, "散弾追加");
            skl_tbl.Add(53, "榴弾追加");
            skl_tbl.Add(54, "拡散弾追加");
            skl_tbl.Add(55, "毒瓶追加");
            skl_tbl.Add(56, "麻痺瓶追加");
            skl_tbl.Add(57, "睡眠瓶追加");
            skl_tbl.Add(58, "強撃瓶追加");
            skl_tbl.Add(59, "属強瓶追加");
            skl_tbl.Add(60, "接撃瓶追加");
            skl_tbl.Add(61, "減気瓶追加");
            skl_tbl.Add(62, "爆破瓶追加");
            skl_tbl.Add(63, "速射");
            skl_tbl.Add(64, "射法");
            skl_tbl.Add(65, "装填数");
            skl_tbl.Add(66, "変則射撃");
            skl_tbl.Add(67, "弾薬節約");
            skl_tbl.Add(68, "達人");
            skl_tbl.Add(69, "痛撃");
            skl_tbl.Add(70, "連撃");
            skl_tbl.Add(71, "特殊会心");
            skl_tbl.Add(72, "属性会心");
            skl_tbl.Add(73, "会心強化");
            skl_tbl.Add(74, "溜め短縮");
            skl_tbl.Add(75, "スタミナ");
            skl_tbl.Add(76, "体術");
            skl_tbl.Add(77, "気力回復");
            skl_tbl.Add(78, "回避性能");
            skl_tbl.Add(79, "回避距離");
            skl_tbl.Add(80, "泡沫");
            skl_tbl.Add(81, "ガード性能");
            skl_tbl.Add(82, "ガード強化");
            skl_tbl.Add(83, "KO");
            skl_tbl.Add(84, "減気攻撃");
            skl_tbl.Add(85, "笛");
            skl_tbl.Add(86, "砲術");
            skl_tbl.Add(87, "重撃");
            skl_tbl.Add(88, "爆弾強化");
            skl_tbl.Add(89, "本気");
            skl_tbl.Add(90, "闘魂");
            skl_tbl.Add(91, "無傷");
            skl_tbl.Add(92, "チャンス");
            skl_tbl.Add(93, "底力");
            skl_tbl.Add(94, "逆境");
            skl_tbl.Add(95, "逆上");
            skl_tbl.Add(96, "窮地");
            skl_tbl.Add(97, "根性");
            skl_tbl.Add(98, "気配");
            skl_tbl.Add(99, "采配");
            skl_tbl.Add(100, "号令");
            skl_tbl.Add(101, "乗り");
            skl_tbl.Add(102, "跳躍");
            skl_tbl.Add(103, "無心");
            skl_tbl.Add(104, "千里眼");
            skl_tbl.Add(105, "観察眼");
            skl_tbl.Add(106, "狩人");
            skl_tbl.Add(107, "運搬");
            skl_tbl.Add(108, "加護");
            skl_tbl.Add(109, "英雄の盾");
            skl_tbl.Add(110, "回復量");
            skl_tbl.Add(111, "回復速度");
            skl_tbl.Add(112, "効果持続");
            skl_tbl.Add(113, "広域");
            skl_tbl.Add(114, "腹減り");
            skl_tbl.Add(115, "食いしん坊");
            skl_tbl.Add(116, "食事");
            skl_tbl.Add(117, "節食");
            skl_tbl.Add(118, "肉食");
            skl_tbl.Add(119, "茸食");
            skl_tbl.Add(120, "野草知識");
            skl_tbl.Add(121, "調合成功率");
            skl_tbl.Add(122, "調合数");
            skl_tbl.Add(123, "高速設置");
            skl_tbl.Add(124, "採取");
            skl_tbl.Add(125, "ハチミツ");
            skl_tbl.Add(126, "護石王");
            skl_tbl.Add(127, "気まぐれ");
            skl_tbl.Add(128, "運気");
            skl_tbl.Add(129, "剥ぎ取り");
            skl_tbl.Add(130, "捕獲");
            skl_tbl.Add(131, "ベルナ");
            skl_tbl.Add(132, "ココット");
            skl_tbl.Add(133, "ポッケ");
            skl_tbl.Add(134, "ユクモ");
            skl_tbl.Add(135, "紅兜");
            skl_tbl.Add(136, "大雪主");
            skl_tbl.Add(137, "矛砕");
            skl_tbl.Add(138, "岩穿");
            skl_tbl.Add(139, "紫毒姫");
            skl_tbl.Add(140, "宝纏");
            skl_tbl.Add(141, "白疾風");
            skl_tbl.Add(142, "隻眼");
            skl_tbl.Add(143, "黒炎王");
            skl_tbl.Add(144, "金雷公");
            skl_tbl.Add(145, "荒鉤爪");
            skl_tbl.Add(146, "燼滅刃");
            skl_tbl.Add(147, "北辰納豆流");
            skl_tbl.Add(148, "胴系統倍加");
            type_tbl.Add(0, "装備なし");
            type_tbl.Add(1, "兵士の護石");
            type_tbl.Add(2, "闘士の護石");
            type_tbl.Add(3, "騎士の護石");
            type_tbl.Add(4, "城塞の護石");
            type_tbl.Add(5, "女王の護石");
            type_tbl.Add(6, "王の護石");
            type_tbl.Add(7, "龍の護石");
        }
       
    }
}