import * as axios from 'axios';
import { from } from 'rxjs';
import { map } from 'rxjs/operators';

const API_URL = 'http://45.32.125.153:44359/api'

export class HttpService {
    constructor() {
        this._addAuthInterceptor();
    }

    doGet(part, query) {
        if (query != null) {
            return from(axios.get(`${API_URL}/${part}?${query}`)).pipe(map(this._mapResponseData));
        }

        return from(axios.get(`${API_URL}/${part}`)).pipe(map(this._mapResponseData));
    }

    doPost(part, data) {
        return from(axios.post(`${API_URL}/${part}`, data)).pipe(map(this._mapResponseData));
    }

    doDelete(part, data) {
        return from(axios.delete(`${API_URL}/${part}`, data)).pipe(map(this._mapResponseData));
    }

    doUpload(part, file, upoadProgressFunc) {
        var data = new FormData();
        data.append('file', file);
        var config = {
            onUploadProgress: upoadProgressFunc,
        };

        return from(axios.post(`${API_URL}/${part}`, data, config)).pipe(map(this._mapResponseData));
    }

    _mapResponseData(res) {
        return res.data;
    }

    _addAuthInterceptor() {
        axios.interceptors.request.use(this._includeToken.bind(this), this._handleError);
    }

    _includeToken(config) {
        let originalRequest = config;
        const token = '';
        if (token) {
            originalRequest.headers['Authorization'] = 'Bearer ' + token;
            return Promise.resolve(originalRequest);
        }
        return config;
    }

    _handleError(error) {
        return Promise.reject(error);
    }
}
