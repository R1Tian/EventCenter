# EventCenter
Unity中的事件中心通用模板

## Unity版本
2020.3.25f1c1

## 项目概述
- 在Unity项目中如果只使用委托来实现跨脚本通信，必然会出现大量互相添加事件的情况
- 针对这个问题我们可以搭建一个事件中心，来**专门添加事件和触发事件**
- 所有脚本通过访问事件中心来注册监听和触发事件，这样做的好处是**解除脚本之间的耦合**

## 事件中心的扩展
- 本事件中心基于UniyAction<T>实现，仅支持调用最多含有一个参数的方法
- 由于UniyAction最多可支持传递4个参数，形如UniyAction<T0, T1, T2, T3>，所以此事件中心可以进行扩展成最多支持传递4个参数

### 扩展方法
1. 新增EventInfo类，例如EventInfo<T0, T1>
2. 新增RegistEvent, unRegistEvent, TriggerEvent的对应重载
