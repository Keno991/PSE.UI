import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { IPullingImagesModel } from './IPullingImagesModel';

import 'rxjs/Rx';

@Injectable()
export class ImgService {

    constructor(private _http: Http) {

    }

    PullImagesFromUrl(url: string): Observable<IPullingImagesModel> {

        return this._http.post("api/ImageUtility?url="+url, null)
            .map(res => {
                console.log(res);
                return <IPullingImagesModel>JSON.parse((<any>res)._body);
            })
    }

}