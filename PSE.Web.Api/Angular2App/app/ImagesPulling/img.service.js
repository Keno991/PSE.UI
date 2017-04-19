var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/Rx';
var ImgService = (function () {
    function ImgService(_http) {
        this._http = _http;
    }
    ImgService.prototype.PullImagesFromUrl = function (url) {
        return this._http.post("api/ImageUtility?url=" + url, null)
            .map(function (res) {
            console.log(res);
            return JSON.parse(res._body);
        });
    };
    return ImgService;
}());
ImgService = __decorate([
    Injectable(),
    __metadata("design:paramtypes", [Http])
], ImgService);
export { ImgService };
//# sourceMappingURL=img.service.js.map