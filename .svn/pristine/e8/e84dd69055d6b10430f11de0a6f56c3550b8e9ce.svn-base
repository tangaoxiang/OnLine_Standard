/**
* MAP对象，实现MAP功能  
*  
* 接口：  
* size()                     获取MAP元素个数  
* isEmpty()                   判断MAP是否为空  
* clear()                        删除MAP所有元素  
* put(key, value)              向MAP中增加元素（key, value)   
* remove(key)                 删除指定KEY的元素，成功返回True，失败返回False  
* get(key)                       获取指定KEY的元素值VALUE，失败返回NULL  
* element(index)                  获取指定索引的元素（使用element.key，element.value获取KEY和VALUE），失败返回NULL  
* containsKey(key)             判断MAP中是否含有指定KEY的元素  
* containsValue(value)          判断MAP中是否含有指定VALUE的元素  
* values()                       获取MAP中所有VALUE的数组（ARRAY）  
* keys()                     获取MAP中所有KEY的数组（ARRAY）  
* 
* 例子：  
* var map = new Map();  
* 
* map.put("key", "value");  
* var val = map.get("key")  
* ……  
* 
*/
function hashmap() {
    /**
     * 存放数据
     */
    this.data = new Object();

    /**
     * 放入一个键值对
     * @param {String} key
     * @param {Object} value
     */
    this.put = function (key, value) {
        this.data[key] = value;
    };

    /**
     * 获取某键对应的值
     * @param {String} key
     * @return {Object} value
     */
    this.get = function (key) {
        return this.containsKey(key) ? this.data[key] : null;
    };

    /**
     * 删除一个键值对
     * @param {String} key
     */
    this.remove = function (key) {
        delete this.data[key];
    };

    /**
     * 遍历Map,执行处理函数
     * 
     * @param {Function} 回调函数 function(key,value,index){..}
     */
    this.each = function (fn) {
        if (typeof fn != 'function') {
            return;
        }
        var len = this.data.length;
        for (var i = 0; i < len; i++) {
            var k = this.data[i];
            fn(k, this.data[k], i);
        }
    };

    /**
     * 获取键值数组(类似Java的entrySet())
     * @return 键值对象{key,value}的数组
     */
    this.entrys = function () {
        var len = this.data.length;
        var entrys = new Array(len);
        for (var i = 0; i < len; i++) {
            entrys[i] = {
                key: i,
                value: this.data[i]
            };
        }
        return entrys;
    };

    /**
     * 判断Map是否为空
     */
    this.isEmpty = function () {
        return this.data.length == 0;
    };

    /**
     * 获取键值对数量
     */
    this.size = function () {
        return this.data.length;
    };

    /**
     * 重写toString ,装成JSON格式
     */
    this.toString = function () {
        var s = "[";
        for (var i = 0; i < this.data.length; i++, s += ',') {
            var k = this.data[i];
            s += "{'id':'" + k + "','value':'" + this.data[k] + "'}";
        }
        s = s.substring(0, s.length - 1);
        if (s != "") {
            s += "]";
        }
        return s;
    };

    /**
     * 输出Value的值
     */
    this.values = function () {
        var _values = new Array();
        for (var key in this.data) {
            _values.push(this.data[key]);
        }
        return _values;
    };

    /**
     * 获取keys
     */
    this.keySet = function () {
        var _keys = new Array();
        for (var key in this.data) {
            _keys.push(key);
        }
        return _keys;
    };

    /**
     * 判断MAP中是否含有指定KEY的元素   
     */
    this.containsKey = function (_key) {
        return (_key in this.data);
    };

    /** 
     * 清空Map 
     */
    this.clear = function () {
        this.data.length = 0;
        this.data = new Object();
    };
}