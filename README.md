### 状态转移图
![Alt text](stateTransitionDiagram.png)
### 数值限制
- hp必须大于0
- atk，def必须大于等于0
- hp, atk, def必须为整数
### 攻击判定
使用trigger类型的碰撞检测，在进入trigger时进行攻击判定并且计算hp
