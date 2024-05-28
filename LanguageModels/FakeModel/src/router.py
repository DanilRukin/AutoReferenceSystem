# В этом файле находятся все endpoints

from fastapi import FastAPI
from service import FakeLanguageModel
from models import RequestText
import time


app = FastAPI()


@app.get('/health')
async def health():
    return {"ok"}



@app.get('/abstract/with_theses/{count}')
async def get_an_abstract_by_theses_count(count: int, request: RequestText):
    start_time = time.time()
    model = FakeLanguageModel()
    response = model.get_an_abstract_by_theses_count(source_text=request.SourceText, theses_count=count)
    end_time = time.time()
    response.SummaryMetrics.RequestTime = end_time - start_time
    return response


@app.get('/abstract/by_abstract_relative_volume/{relative_volume}')
async def get_an_abstract_by_abstract_relative_volume(relative_volume: float, request: RequestText):
    start_time = time.time()
    model = FakeLanguageModel()
    response = model.get_an_abstract_by_abstract_relative_volume(request.SourceText, abstract_relative_volume=relative_volume)
    end_time = time.time()
    response.SummaryMetrics.RequestTime = end_time - start_time
    return response


@app.get('/abstract/with_specified_words_count/{count}')
async def get_an_abstract_with_specified_words_count(count: int, request: RequestText):
    start_time = time.time()
    model = FakeLanguageModel()
    response = model.get_an_abstract_with_specified_words_count(source_text=request.SourceText, words_count=count)
    end_time = time.time()
    response.SummaryMetrics.RequestTime = end_time - start_time
    return response
    


@app.get('abstract/with_specified_sentesies_count/{count}')
async def get_an_abstract_with_specified_sentesies_count(count: int, request: RequestText):
    start_time = time.time()
    model = FakeLanguageModel()
    response = model.get_an_abstract_with_specified_sentesies_count(source_text=request.SourceText, sentensies_count=count)
    end_time = time.time()
    response.SummaryMetrics.RequestTime = end_time - start_time
    return response
    

