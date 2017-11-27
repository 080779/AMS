
//ajax提交分页
function getPage(pageIndex) {
    $.ajax({
        url: "/home/pagedata?pageindex=" + pageIndex, type: "post",
        success: function (result) {
            $("#pager").empty();
            $("#pager").append(result.data.pageHTML);
            $("#load").empty();
            for (var i = 0; i < result.data.idNames.length; i++) {
                $("#load").append("<tr><td>" + result.data.idNames[i].id + "</td><td>" + result.data.idNames[i].typeName + "</td><td>" + result.data.idNames[i].name + "</td></tr>");
            }
        },
        error: function () { alert("网络错误"); }
    });
}


$.ajax({
    url: "", type: "post", data: {},
    success: function (result) {
    },
    error: function () { alert("网络错误"); }
});


<script type="text/javascript">
    var pageIndex = 1;//当前数据页码
mui.init({
    pullRefresh: {
        container: refreshContainer,//待刷新区域标识，querySelector能定位的css选择器均可，比如：id、.class等
        up: {
            height: 50,//可选.默认50.触发上拉加载拖动距离
            auto: true,//可选,默认false.自动上拉加载一次
            contentrefresh: "正在加载...",//可选，正在加载状态时，上拉加载控件上显示的标题内容
            contentnomore: '没有更多数据了',//可选，请求完毕若没有更多数据时显示的提醒内容；
            callback: function () {
                var prThis = this;
                $.ajax({
                    url: "/House/LoadMore" + location.search + "&pageIndex=" + pageIndex,
                    type: "post", dataType: "json",
                    success:function(res)
                    {
                        //alert(res);
                        pageIndex++;//页码++
                        var hasMoreData = (res.data.length == 10);//是否有更多的数据
                        //for (var i = 0; i < res.data.length;i++)
                        //{
                        //$("<li>"+res.data[i].communityName+"</li>").appendTo($("#ul1"));
                        //}
                        var html = template('housesList', { houses: res.data });
                        //alert(html);
                        $("#ul1").append($(html));
                        prThis.endPullupToRefresh(!hasMoreData);
                        //this.endPullupToRefresh(!hasMoreData);
                    },
                    error: function () {
                        alert("加载数据失败");
                    }
                });

                this.endPullupToRefresh(false);
            } //必选，刷新函数，根据具体业务来编写，比如通过ajax从服务器获取新数据；
        }
    }
});
</script>
<script id="housesList" type="text/html">
    {{each houses as h}}
    <div class="list clearfloat fl box-s">
        <a href="/{{h.id}}.html">
            <!--<a href="/House/Index/{{h.id}}">-->
            <div class="tu clearfloat">
                <span></span>
                <img src="{{h.firstThumbUrl}}" />
            </div>
            <div class="right clearfloat">
                <div class="tit clearfloat">
                    <p class="fl">{{h.communityName}}</p>
                    <span class="fr">{{h.monthRent}}<samp>元/月</samp></span>
                </div>
                <p class="recom-jianjie">{{h.roomTypeName}}   |  {{h.area}}m²  |  {{h.decorateStatusName}}</p>
                <div class="recom-bottom clearfloat">
                    <span><i class="iconfont icon-duihao"></i>随时住</span>
                    <span><i class="iconfont icon-duihao"></i>家电齐全</span>
                </div>
            </div>
        </a>
    </div>
{{/each}}
</script>