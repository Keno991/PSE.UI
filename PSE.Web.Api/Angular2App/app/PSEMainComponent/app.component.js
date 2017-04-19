var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { ImgService } from '../ImagesPulling/img.service';
var AppComponent = (function () {
    function AppComponent(_http, _imgSvc) {
        this._http = _http;
        this._imgSvc = _imgSvc;
    }
    AppComponent.prototype.pullImages = function () {
        var _this = this;
        var url = this.selectedUrl;
        this.selectedUrl = 'Processing...';
        this._imgSvc.PullImagesFromUrl(url).subscribe(function (pullingImgs) {
            _this.selectedUrl = pullingImgs.DownloadedImagesCount + " images out of " + pullingImgs.ImagesCount + " downloaded.";
        }, function (error) {
            _this.selectedUrl = 'error occured';
        });
    };
    return AppComponent;
}());
AppComponent = __decorate([
    Component({
        selector: 'my-app',
        templateUrl: './pse.main.html'
    }),
    __metadata("design:paramtypes", [Http, ImgService])
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map