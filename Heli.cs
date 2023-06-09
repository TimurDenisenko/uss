﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace uss
{
    public class Heli
    {

        public async Task Tagaplaanis_Mangida(string Path)
        {
            await Task.Run(() =>
            {
                using (AudioFileReader audiFileReader = new AudioFileReader(Path))
                using (IWavePlayer waveOutDevice = new WaveOutEvent { DesiredLatency = 200, Volume=50})
                {
                    waveOutDevice.Init(audiFileReader);
                    waveOutDevice.Play();
                    while (waveOutDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
        }

        public async Task Natuke_Mangida(string Path)
        {
            await Task.Run(() =>
            {
                using (AudioFileReader audiFileReader = new AudioFileReader(Path))
                using (IWavePlayer waveOutDevice = new WaveOutEvent())
                {
                    waveOutDevice.Init(audiFileReader);
                    waveOutDevice.Play();
                    while (waveOutDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(50);
                    }
                }
            });
        }
    }
}
